;_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/#
;パッチ名：画像フォルダ名チェック機能追加パッチ
;作者：
;作成日：2024/12/24
;
;作成内容の概要：
;　○衣装「ダンジョン衣装」と差分「奥義ゲージMAX」について、短冊画像もチェックするように変更
;
;　○マッサージ関連差分(マッサージ仰向け、マッサージうつ伏せ)をチェック対象に追加
;
;　○フォルダ名チェックでサブフォルダが正常にチェックできなくなっていた不具合を修正
;
;　○pngファイルに対応していない旨の記載追加
;
;作成内容の概要：
;　・画像ファイル名チェック機能にフォルダ名のチェック機能を追加します
;　　チェック実行時、名前が間違っている画像フォルダがあった場合はフォルダ名の修正候補を出力します
;　・消し忘れていたデバッグ用出力を削除しました
;　・誤記訂正
;
;　<注意点>
;　・画像ファイル名チェック機能に追加した形のため、同様にデバッグモード専用の機能になっています
;　・「顔_デフォルト.png」がないフォルダはチェック対象外です
;　・ランダムキャラ(CSV番号999)のフォルダについては修正候補が出力されません
;　・番号が間違っている場合、キャラ名が間違っている場合の両方のケースを想定して修正候補を出力しますが、
;　　番号とキャラ名の両方間違っている場合は修正候補は出力されません
;　・例外ケース処理の都合で使用するCSV番号が10142に到達した場合は修正が必要になります
;
;_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/#
;ライセンスについて
;	・基本項目(許可する項目を"○"に、許可しない項目を"×"に変更してください。)
;	+----+----+-------------------------------------------+
;	|番号|許可|ライセンス内容                             |
;	+----+----+-------------------------------------------+
;	|   1| ○ | 処理上のバグ修正                          |
;	+----+----+-------------------------------------------+
;	|   2| ○ | 新規機能追加による内容改変                |
;	+----+----+-------------------------------------------+
;	|   3| ○ | バランス調整による内容改変                |
;	+----+----+-------------------------------------------+
;	|   4| ○ | 口上の誤字・脱字の修正                    |
;	+----+----+-------------------------------------------+
;	|   5| ○ | 口上の新規追加・加筆                      |
;	+----+----+-------------------------------------------+
;	|   6| ○ | 既存口上の改変                            |
;	+----+----+-------------------------------------------+
;	|   7| ○ | 改変した口上の自由な再配布                |
;	+----+----+-------------------------------------------+
;	|   8| ○ | 口上内容の転載（erablue_resort内部に限る）|
;	+----+----+-------------------------------------------+
;	|   9| ○ | erablue_resort本体への収録                |
;	+----+----+-------------------------------------------+
;※１～８番の項目のいずれかを許可していない場合、９番の項目は自動的に許可していないと扱います
