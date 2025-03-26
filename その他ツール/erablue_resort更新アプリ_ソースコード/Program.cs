using System;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using System.Collections.Generic;
using System.Resources;
using System.Globalization;
using erablue_resort更新アプリ;

class Program
{
    private static readonly HttpClient _httpClient = new HttpClient();
    private static readonly ResourceManager rm = new ResourceManager("GitCloner.Resources", typeof(Program).Assembly);

    public static void CopyDirectory(string sourceDirName, string destDirName)
    {
        if (!Directory.Exists(destDirName))
        {
            Directory.CreateDirectory(destDirName);
        }
        if (destDirName[^1] != Path.DirectorySeparatorChar)
            destDirName += Path.DirectorySeparatorChar;

        var files = Directory.EnumerateFiles(sourceDirName);
        foreach (string file in files)
            File.Copy(file, destDirName + Path.GetFileName(file), true);

        var dirs = Directory.EnumerateDirectories(sourceDirName);
        foreach (string dir in dirs)
            CopyDirectory(dir, destDirName + Path.GetFileName(dir));
    }

    public static void CopyFileOrDirectory(string sourcePath, string destPath)
    {
        if (File.Exists(sourcePath))
        {
            string? dirName = Path.GetDirectoryName(destPath);
            if (!string.IsNullOrEmpty(dirName))
            {
                Directory.CreateDirectory(dirName);
            }
            File.Copy(sourcePath, destPath, true);
        }
        else if (Directory.Exists(sourcePath))
        {
            CopyDirectory(sourcePath, destPath);
        }
    }

    public static void DeleteFileOrDirectory(string path)
    {
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        else if (Directory.Exists(path))
        {
            Directory.Delete(path, true);
        }
    }

    /// <summary>
    /// GitHubからZIPをダウンロードして展開（.gitなし）
    /// </summary>
    private static async Task DownloadAndExtractZip(string repoUrl, string workdirPath)
    {
        // GitHubリポジトリのZIP URLを生成
        string zipUrl = repoUrl.Replace("github.com", "github.com") + "/archive/refs/heads/main.zip";
        if (zipUrl.StartsWith("https://github.com"))
        {
            zipUrl = zipUrl.Replace("https://github.com", "https://github.com");
        }
        else
        {
            throw new ArgumentException(Resources.URLerror);
        }

        Console.WriteLine(Resources.DownloadMessage ?? "リポジトリをダウンロード中: {0}", zipUrl);

        // ZIPを一時ファイルにダウンロード
        string tempZipPath = Path.Combine(Path.GetTempPath(), "repo_temp.zip");
        using (var response = await _httpClient.GetAsync(zipUrl))
        {
            response.EnsureSuccessStatusCode();
            using (var stream = await response.Content.ReadAsStreamAsync())
            using (var fileStream = File.Create(tempZipPath))
            {
                await stream.CopyToAsync(fileStream);
            }
        }

        // 既存のディレクトリを一旦保存
        string savePath = workdirPath + "_バックアップ用";
        if (Directory.Exists(workdirPath))
        {
            Directory.Move(workdirPath, savePath);
        }

        // ZIPを展開
        Console.WriteLine(Resources.zipopen ?? "ZIPファイルを展開中...");
        ZipFile.ExtractToDirectory(tempZipPath, workdirPath);

        // 一時ファイルを削除
        File.Delete(tempZipPath);

        // 展開されたフォルダ名を調整（GitHubは「リポジトリ名-ブランチ名」形式）
        string extractedDir = Directory.GetDirectories(workdirPath)[0];
        foreach (var file in Directory.GetFiles(extractedDir))
        {
            File.Move(file, Path.Combine(workdirPath, Path.GetFileName(file)));
        }
        foreach (var dir in Directory.GetDirectories(extractedDir))
        {
            Directory.Move(dir, Path.Combine(workdirPath, Path.GetFileName(dir)));
        }
        Directory.Delete(extractedDir, true);

        Console.WriteLine(Resources.downloadok ?? "最新データの取得が完了しました");
    }

    private static void SyncWithPreservation(string sourceUrl, string basePath, IEnumerable<string> overwriteFolderNames, IEnumerable<string> noActionFolderNames)
    {
        List<string> overwritePaths = overwriteFolderNames.Select(name => Path.Combine(basePath, name)).ToList();
        List<string> noActionPaths = noActionFolderNames.Select(name => Path.Combine(basePath, name)).ToList();
        string tempDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "erablue_resort_temp_" + Guid.NewGuid().ToString());

        try
        {
            Console.WriteLine(Resources.startnew ?? "同期処理を開始します");

            // 1. 既存の overwrite と noaction を退避
            foreach (string overwritePath in overwritePaths)
            {
                if (Directory.Exists(overwritePath))
                {
                    string tempExistingOverwrite = Path.Combine(tempDir, "existing_overwrite_" + Path.GetFileName(overwritePath));
                    string? dirName = Path.GetDirectoryName(tempExistingOverwrite);
                    if (!string.IsNullOrEmpty(dirName))
                    {
                        Directory.CreateDirectory(dirName);
                    }
                    CopyDirectory(overwritePath, tempExistingOverwrite);
                    Console.WriteLine(Resources.foldersave ?? "{0} を退避しました", Path.GetRelativePath(basePath, overwritePath));
                }
            }
            foreach (string noActionPath in noActionPaths)
            {
                if (File.Exists(noActionPath) || Directory.Exists(noActionPath))
                {
                    string tempExistingNoAction = Path.Combine(tempDir, "existing_noaction_" + Path.GetFileName(noActionPath));
                    string? dirName = Path.GetDirectoryName(tempExistingNoAction);
                    if (!string.IsNullOrEmpty(dirName))
                    {
                        Directory.CreateDirectory(dirName);
                    }
                    CopyFileOrDirectory(noActionPath, tempExistingNoAction);
                    Console.WriteLine(Resources.foldersave ?? "{0} を退避しました", Path.GetRelativePath(basePath, noActionPath));
                }
            }

            // 2. 最新版をZIPで取得（.gitなし）
            DownloadAndExtractZip(sourceUrl, basePath).GetAwaiter().GetResult();

            // 3. 最新版の overwrite を退避
            foreach (string overwritePath in overwritePaths)
            {
                if (Directory.Exists(overwritePath))
                {
                    string tempNewOverwrite = Path.Combine(tempDir, "new_overwrite_" + Path.GetFileName(overwritePath));
                    string? dirName = Path.GetDirectoryName(tempNewOverwrite);
                    if (!string.IsNullOrEmpty(dirName))
                    {
                        Directory.CreateDirectory(dirName);
                    }
                    CopyDirectory(overwritePath, tempNewOverwrite);
                }
            }

            // 4. 最新版の overwrite と noaction を削除
            foreach (string overwritePath in overwritePaths)
            {
                if (Directory.Exists(overwritePath))
                {
                    Directory.Delete(overwritePath, true);
                }
            }
            foreach (string noActionPath in noActionPaths)
            {
                if (File.Exists(noActionPath) || Directory.Exists(noActionPath))
                {
                    DeleteFileOrDirectory(noActionPath);
                }
            }

            // 5. 退避していた既存の overwrite と noaction を復元
            foreach (string overwritePath in overwritePaths)
            {
                string tempExistingOverwrite = Path.Combine(tempDir, "existing_overwrite_" + Path.GetFileName(overwritePath));
                if (Directory.Exists(tempExistingOverwrite))
                {
                    string? dirName = Path.GetDirectoryName(overwritePath);
                    if (!string.IsNullOrEmpty(dirName))
                    {
                        Directory.CreateDirectory(dirName);
                    }
                    CopyDirectory(tempExistingOverwrite, overwritePath);
                    Console.WriteLine(Resources.folderload ?? "{0} を退避から復元しました", Path.GetRelativePath(basePath, overwritePath));
                }
            }
            foreach (string noActionPath in noActionPaths)
            {
                string tempExistingNoAction = Path.Combine(tempDir, "existing_noaction_" + Path.GetFileName(noActionPath));
                if (File.Exists(tempExistingNoAction) || Directory.Exists(tempExistingNoAction))
                {
                    string? dirName = Path.GetDirectoryName(noActionPath);
                    if (!string.IsNullOrEmpty(dirName))
                    {
                        Directory.CreateDirectory(dirName);
                    }
                    CopyFileOrDirectory(tempExistingNoAction, noActionPath);
                    Console.WriteLine(Resources.folderload ?? "{0} を退避から復元しました", Path.GetRelativePath(basePath, noActionPath));
                }
            }

            // 6. 退避していた最新版の overwrite を上書き
            foreach (string overwritePath in overwritePaths)
            {
                string tempNewOverwrite = Path.Combine(tempDir, "new_overwrite_" + Path.GetFileName(overwritePath));
                if (Directory.Exists(tempNewOverwrite))
                {
                    string? dirName = Path.GetDirectoryName(overwritePath);
                    if (!string.IsNullOrEmpty(dirName))
                    {
                        Directory.CreateDirectory(dirName);
                    }
                    CopyDirectory(tempNewOverwrite, overwritePath);
                    Console.WriteLine(Resources.folderoverwrite ?? "{0} を最新版で上書きしました", Path.GetRelativePath(basePath, overwritePath));
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(Resources.Exceptionerror1 ?? "同期処理中にエラーが発生しました: {0}", ex.Message);
            Console.WriteLine(basePath, Resources.Exceptionerror2 ?? " を確認し、必要に応じて削除してください。");
            throw;
        }
        finally
        {
            if (Directory.Exists(tempDir))
            {
                try
                {
                    Directory.Delete(tempDir, true);
                    Console.WriteLine(Resources.tempDirok ?? " 一時ディレクトリを削除しました");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(tempDir, Resources.tempDirerror1 ?? "一時ディレクトリの削除に失敗しました: {0}", ex.Message);
                    Console.WriteLine(Resources.tempDirerror2 ?? "手動で削除してください。");
                }
            }
        }
    }

    static (string sourceUrl, List<string> overwriteFolders, List<string> noActionFolders) LoadConfig(string configPath)
    {
        if (!File.Exists(configPath))
        {
            throw new FileNotFoundException($"設定ファイル '{configPath}' が見つかりません。");
        }

        var lines = File.ReadAllLines(configPath, Encoding.UTF8);
        string sourceUrl = null;
        var overwriteFolders = new List<string>();
        var noActionFolders = new List<string>();
        string currentSection = null;

        foreach (var line in lines)
        {
            var trimmedLine = line.Trim();
            if (string.IsNullOrEmpty(trimmedLine) || trimmedLine.StartsWith("#")) continue;

            if (trimmedLine.StartsWith("SourceUrl="))
            {
                sourceUrl = trimmedLine.Substring("SourceUrl=".Length).Trim();
            }
            else if (trimmedLine == "OverwriteFolders=")
            {
                currentSection = "OverwriteFolders";
            }
            else if (trimmedLine == "NoActionFolders=")
            {
                currentSection = "NoActionFolders";
            }
            else if (currentSection == "OverwriteFolders")
            {
                overwriteFolders.Add(trimmedLine);
            }
            else if (currentSection == "NoActionFolders")
            {
                noActionFolders.Add(trimmedLine);
            }
        }

        if (string.IsNullOrEmpty(sourceUrl))
        {
            throw new InvalidOperationException("設定ファイルに SourceUrl が指定されていません。");
        }

        return (sourceUrl, overwriteFolders, noActionFolders);
    }

    static async Task Main(string[] args)
    {
        CultureInfo ci = CultureInfo.CurrentCulture; // または特定カルチャを指定:
        //CultureInfo ci = new CultureInfo("ja-JP");
        Thread.CurrentThread.CurrentCulture = ci;
        Thread.CurrentThread.CurrentUICulture = ci;

        try
        {
            Console.OutputEncoding = Encoding.UTF8;
            // LibGit2Sharpを使わないのでバージョン表示は不要
            // Console.WriteLine($"LibGit2Sharp Version: {typeof(Repository).Assembly.GetName().Version}");

            string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string configPath = Path.Combine(exeDirectory, "config.txt");
            var (sourceUrl, overwriteFolderNames, noActionFolderNames) = LoadConfig(configPath);

            string basePath = Path.Combine(exeDirectory, "erablue_resort");

            //// 複数の相対パスを指定（ファイル名含む）
            //var overwriteFolderNames = new List<string>
            //{
            //    "resources"
            //};
            //var noActionFolderNames = new List<string>
            //{
            //    "sav",
            //    "emuera.config",
            //    "CSV_EDITFILE",
            //    "CSV/ローカル追加用CSV",
            //    "ERB_EDITFILE",
            //    "ERB/ローカル改造用ERB"
            //};

            SyncWithPreservation("https://github.com/erablue-resort/erablue_resort", basePath, overwriteFolderNames, noActionFolderNames);

            await Task.Delay(3000);
            Console.WriteLine(Resources.Allok ?? " すべての更新を完了しました");
            string savePath = basePath + "_バックアップ用";
            if (Directory.Exists(savePath))
            {
                Directory.Delete(savePath, true);
                Console.WriteLine(Resources.Floderdel ?? " 更新前のフォルダを削除しました");
            }
        }
        catch (Exception ex)
        {
            AnsiConsole.WriteException(ex);
            Console.WriteLine(Resources.writeerror ?? "エラーが発生しました。問題のあるフォルダを消してリトライしてください");
            Console.ReadLine();
        }

        Console.ReadKey();
    }
}