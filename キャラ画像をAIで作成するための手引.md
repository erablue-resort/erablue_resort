# はじめに
『erablueresortで使用する画像』を、AI生成にて用意するときの手引書…というより、プロンプト備忘録です。  
AI画像生成のローカル環境の構築や各種ウェブサイトの使い方なんかは各自調べてみてください。  
このファイルよりよほど丁寧に詳しく書いてあります。  
先述のとおり、このファイルではプロンプトの例示を主に行っています。  
用意するAIイラストはpngかwebpで命名規則が「___キャラ画像の入れ方.txt」に即している必要があります。  
逆に言えば、サイズとかは（自分自身で使用するだけなら）気にしなくてもera側で勝手に調整するようにできています。  
何なら短冊画像もなくてもいいです。顔_〇〇.png の画像を縦長で用意すれば、そこそこいい感じで表示されるはずです。  
（AIイラストが今ほど盛んじゃ無い時代、本家から編成画面の縦長画像拾ってきてリネームしてもそれなりに見れるように設計されたため）  
## 共通で使用するおまじない
`masterpiece, best quality, amazing quality, very aesthetic, absurdres, (painted by minaba hideo), granblue fantasy, official art, solo, `  
painted～以降はお好みで。

## キャラの特徴
`1girl, [キャラ名], [作品名], [髪の色], [髪の長さ], [瞳の色], [頭の装飾品], `

## 表情や背景、構図、体位など
danbooruから検索かけて探してみましょう。  
見つけにくい所だと、着衣のマンスジは`cameltoe, `、全裸の一本スジは`cleft of venus, `です。自作なら`uncensored, `で無修正も表示し放題！やったね！  
下の呪文を試してみて、思ったような構図にならない場合は、表示されないはずの部分の単語を消してみてください。  
足を入れたくない場合、`cowboy shot, `や`upper body, `を加筆すると共に、`boots, `や`shoe, `、`legwear, `などの単語を含む部分を削るといった具合です。  
再現度が低い場合、https://civitai.com/ からLoRAを探してみるのも一つの手です。

## 要素の強調、抑制
強調したい部分は`(XXX:1.2), `、ふんわりと入れたい部分は`(XXX:0.8), `といった具合に()で括り、:の後ろに数字を入れて強弱をつけてみましょう。  
1を基準に小数点で調節しますが、0.6～1.4から逸脱すると出来上がりが破綻しやすくなるので注意。  
()で1回括るごとに1.1倍されたり、[]で1回括るごとに0.91倍されますが、後から確認しづらくなるので数字で指定したほうが無難です。  
出るのを抑制したい要素がある場合はネガティブプロンプトに記載しましょう。  
それでも出る場合は上記の強調と同じように1.0より大きい数字を入れるとよいでしょう。

## 想定外の要素が頻出する場合
ネットで調べたプロンプトを試していると、想定外の要素が頻出する場合、上記のdanbooruの検索窓に一つずつプロンプトを入れて、登録されているか、登録数は800以上あるかを確認してみましょう。  
ない場合や、検索して出てくるイラスト一覧にその想定外の要素をよく見かける場合は、そのプロンプトが余計な働きをしている可能性があります。一度、削除して作成してみましょう。  
一例として、「fair skin（肌を美白するプロンプトとしてよく紹介されている）」がエルフ耳のトリガーになっていたことがありました。 

## PixAiを使っているがクレジットが足りない場合
LoRA「dmd2_sdxl_4step_lora」を使ってみましょう。  
このLoRAを適応した上で、STEP:8 CFG:1.5で作成すると高速生成でも1200クレジットで生成可能です。  
他、「Illustrious XL personal merge (noob v-pred0.5 test merge updated)」などの低STEP対応のモデルを使用してみるのも手です。  
ただし書き込みが過剰になる場合があるのと、ネガティブプロンプトが効かなくなる点には注意が必要です。

## コスプレさせたい場合
以下の呪文はあくまで一例です。再現率が低いと感じた場合、LoRAを探してみてください。  
キャラクターLoRAを使用し、`\(cosplay\), `を追記するとうまくいくこともあります。  
{}内は書きたい衣装に応じて|で区切られているどれかを使用するといいかも。  
（ローカルならDynamic Promptsってオプションを有効化してそのまま放りこんだら勝手にランダムで選んでくれます）  
{AA|BB|CC}は|で区切られた中からどれか１つを選択、{XX}は入れたい場合に{}を外して追加

# 衣装プロンプト
## 一般的な衣装
### 全裸
`completely nude, nipples, `  
必要に応じて下の毛`pubic hair`やら縦スジ`cleft of venus`やらマンコ`pussy`やら
### 湯浴み着
`naked towel, towel on head, `
### バスローブ
`bathrobe, towel on head, `  
胸元を閉じさせたい場合は`cleavage`をネガティブに入れるか、`covered cleavage`などでインナーを着せること
### マッサージ着
既存画像はキャラによってビキニだったり裸タオルだったり施術着だったり色々。  
データ的には脇・ヘソが露出してないが脱がさずパイズリ・挿入ができる下着なしの衣装という扱い。  
裸タオルとビキニはあるので施術着タイプだと`grey shirt, grey shorts, `
### 浴衣
`yukata, `
### ヨガウェア
`crop top, midriff, navel, pants, yoga pants, sports bra, `
### 常夏のアロハスタイル
`collared shirt, floral print, hawaiian shirt, short shorts, floral print shorts, `
### 淫蕩のアロハスタイル
`collared shirt, floral print, hawaiian shirt, {tied shirt, front-tie top, navel, |(short cropped shirt:1.5), open clothes|open clothes}, center opening, areola slip, naked shirt, micro shorts, lowleg shorts, no panties, `  
{}内は前半だと胸の下で結ぶ形、真ん中だと胸の下辺りの丈で前全開き、後半だと長丈で前全開きが出やすくなるはずです
### 裸エプロン
`naked apron, `
### つやつや光沢服
`seamless latex bodysuits, `  
お好みでzipper, stitch, seam, をネガティブプロンプトに入れるとジッパーや縫い目が消えて見た目がすっきりします。

## 水着類
### 水着
`swimsuit, {bikini| one-piece swimsuit| bikini shorts| slingshot swimsuit}, `
### マイクロビキニ
`micro bikini, `
### ウエディングビキニ
`wedding dress, bridal veil, white bikini, garter belt, white garter belt, lace bra, side-tie panties, white thighhighs, underwear, midriff, `
### 逮捕しちゃうゾ
`highleg bikini, stomach, police, police uniform, jacket, cropped jacket, policewoman, green armband, blue bikini, blue necktie, long sleeves, underboob, sideboob, cleavage, ((blue shirt)), groin, open clothes, tie clip, star (symbol), garrison cap, open jacket, shrug (clothing), collared shirt, blue headwear, string bikini, blue jacket, micro bikini, police hat, necktie between breasts, sleeve cuffs, skindentation, epaulettes, aiguillette, police badge, white gloves, blue thighhighs, thigh boots, `
### スリングショット
`slingshot swimsuit, {blue|pink|black|など好きな色} slingshot swimsuit, {areola slip}, {criss-cross halter}, `

## 仕事の制服
### リゾート従業員制服
`{juliet sleeves|compression sleeve}, black sleeves, long sleeves, red necktie, {上}, {下}, `  
{上}・{下}は以下の要素の区分を一つずつ選び{上}・{下}に入れてください。
| 区分 | 種類 | プロンプト | 
| :---: | :---: | --- | 
| 上 | スーツ | `black suit, white shirt, dress shirt, business suit` |
| 上 | 胸部露出 | `black suit, navel, center opening, necktie between breasts` |
| 上 | トップレス | `topless, nipples, navel` |
| 上 | トップレス＆乳首に名札 | `topless, nipples, navel, 5afety pin, nipple safety pin piercing, name tag attached, name tag attached`<br>（LoRA:Safety_Pin_NAI_v1を使用） |
| 下 | ロングパンツ | `black pants` |
| 下 | ミニスカート | `black skirt, miniskirt, pencil skirt` |
| 下 | スカート | `black skirt, long skirt, pencil skirt` |
| 下 | ボトムレス | `bottomless, cleft of venus, black kneehighs, (black shoes:0.8)` |
### つやつや従業員制服
`black latex suit vest, red bolo tie, long sleeves, (white latex shirt:1.25), collared shirt, name tag, black latex pencil skirt, black thigh boots, high heel boots, `
### バニー服
`playboy bunny, `
### 逆バニー
`reverse bunnysuit, `
### メイド服
`maid, maid headdress, blouse, `
### ミニメイド服
`maid, maid headdress, miniskirt, cleavage, `
### ナース服
`nurse, nurse cap, white pantyhose, `  
万が一があるとややこしいので`red cross`（赤十字）はネガティブプロンプトに入れるか手作業で消すことを推奨
### ミニスカサンタ
`santa costume, miniskirt, santa hat, `
### 喫茶店従業員服
`{white|blue|red|など好きな色} t-shirt, long sleeve, {blue|pink|black|など好きな色} long skirt, simple green apron, `
### 喫茶店従業員服（特殊業務）
`naked apron, simple green apron, `
### 修道服
`church, traditional nun, long dress, long sleeves, coif, white collar, `
### 破戒修道服
`church, coif, nun, black nun, underboob, cleavage, breast curtains, pelvic curtains, white gloves, white thighhighs, garter straps, juliet sleeves, `
### 巫女装束
`miko, `
### セクシー巫女服
`nontraditional miko, japanese clothes, red back bow, white kimono, crop top, bare shoulders, detached sleeves, wide sleeves, long sleeves, navel, sash, hakama skirt, hakama short skirt, red hakama, red skirt, pleated skirt, miniskirt, microskirt, garter straps, thighs, thighhigh, white thighhighs, {sideboob, cleavage|clothes between breasts, ofuda on nipples}, {ofuda on pussy}, `
### 蠱惑の舞姫
`harem outfit, arabian costume, mouth veil, covered mouth, harem pants, crotchless pants, puffy sleeves, see-through clothes, breast curtains, pelvic curtain, highleg panties, toeless legwear, `
### リゾート警備制服
`policewoman, police uniform, blue headwear, {garrison cap|police hat}, jacket, cropped jacket, long sleeves, open clothes, open jacket, shrug \(clothing\), blue jacket, sleeve cuffs, blue necktie, (white shirt:1.25), midriff cropped shirt, collared shirt, police badge, white gloves, blue mini skirt, black duty belt, thigh boots, high heel boots, `  
胸ベルトはいらない！と思ったらchest harnessをネガティブに入れるといいと思います。  
逆に欲しい！って人はchest harnessを追加してください。
### セクシーポリス
`policewoman, police uniform, blue headwear, {police hat|garrison cap}, police badge, jacket, blue latex jacket, cropped jacket, open jacket, shrug clothing, open clothes, long sleeves, sleeve cuffs, police badge, blue necktie, (white shirt:1.25), collared shirt, breastless shirt, bare stomach, gold star pasties, white gloves, blue latex skirt, ultra microskirt, lowleg skirt, pencil skirt, lowleg,  black string panties, latex panties, thigh boots, high heel boots, {chest harness, shoulder holster|black duty belt, holster|thigh holster}, `  
ホルスター位置は上から順に脇｜腰｜太ももとなっております。
### 花魁ノ御華
`oiran, kimono, japanese clothes, nihongami, obi, sash, bare shoulders, wide sleeves, `
### 普通のオーバーオール
`{crew neck t-shirtなどの動きやすそうな服}, {denimなどの好きな素材} oversized overalls, long length overalls, `
### 裸ミニスカオーバーオール
`{denimなどの好きな素材} overalls, super micro skirt overalls, naked overalls, `
### スーパーセクシー巫女服
`nontraditional miko, miko clothes, shrug miko clothes, wide sleeves, nipples, midriff, navel, red hakama, hakama skirt, microskirt, lowleg skirt, pussy, white thighhighs, `  
bare pussyで思った通りの袴の位置にならないことが多いがご愛嬌ということで！いいプロンプトがあれば教えてほしいです！改定案をAIプロンプト談議で待っております！
### 破廉恥麦酒祭従業員制服
`dirndl, breastless dirndl, long sleeves, crop top dirndl, micro apron, bare pussy, `
## 学校関係
### 学生服
`school uniform, {serafuku, sailor collar, neckerchief, shirt, skirt, pleated skirt| blazer, collared shirt, jacket, skirt, pleated skirt, bowtie}, `
### スモック
`kindergarten uniform, yellow hat, name tag, `
### 体操着
`gym uniform, gym shirt, {buruma| shorts}, `
### バスケユニ
`basketball uniform, `
### チアリーダー
`cheerleader, short sleeves, covered navel, holding pom poms, `
### セクシーチア
`cheerleader, collarbone, sleeveless, midriff, cleavage, see-through clothes, bra, string panties, miniskirt, highleg panties, holding pom poms, `
### アメスク
`amesuku gyaru, gyaru, kogal, open shirt, tied shirt, leopard print, navel, bikini under clothes, microskirt, collared shirt, pleated skirt, underwear, highleg panties, `
### レオタード
`athletic leotard, leotard, long sleeves, `
### シースルーレオタード
`leotard, latex leotard, transparent leotard, translucent bunnysuit, `
### テニスウェア
`tennis uniform, {{white|black|など好きな色やsee-through} {visor cap|head band}}, {white|black|など好きな色} polo shirt, short sleeves, {{white|black|など好きな色} sweatband}, {white|black|など好きな色} skirt, miniskirt, `  
ロングヘアキャラにお好みで`high ponytail`を追加しましょう。
### ヤリサーテニスウェア
`tennis uniform, {{white|black|など好きな色} {visor cap|head band}}, {white|black|など好きな色} shrug shirt, sleeveless shirt, bare breasts, {{white|black|など好きな色} sweatband}, {white|black|など好きな色} microskirt, `  
ロングヘアキャラにお好みで`high ponytail`を追加しましょう。
## 結婚式衣装
### ウエディングドレス
`wedding dress, bridal veil, white dress, long skirt, bridal gauntlets, `
### ホワイトタキシード
`white suit, formal clothes, tuxedo, {black|white|red} {bowtie|necktie}, dress pants, white shirt, {black|grey} waistcoat, `
### 生き恥ウエディングドレス
`revealing princess line wedding dress, wedding ring, pure white lace, long train, classic bridal look, bridal gauntlets, crop top, sleeveless shirt, turtleneck, bare shoulder, bustier, midriff, cupless bra, nipples, navel, crotchless panties, pussy, garter belt, bridal garter, garter strap, white thighhighs, `
## ドレス系
### チャイナドレス
`china dress, short sleeves, `
### ミニチャイナ
`china dress, cleavage, short pelvic curtain, `
### セクシーキョンシー
`china dress, chinese clothes, breast cutout, pelvic curtain, jiangshi costume, qingdai guanmao, ofuda on head, ofuda on pussy, ofuda on nipples, pasties, `
### ゴールデンバブリードレス
`gold dress, bodycon, strapless, tube dress, disco ball, dancer, tube top, sequins, fur shawl, pencil dress, no sleeves, `  
<u>*打率は低め*</u>
### 晴れ着
`furisode, kimono, obijime, obiage, sash, fur trim, `
### ロングドレス
`long dress, {white|blue|red|など好きな色} dress, juliet sleeves, puffy sleeves, long sleeves, `

## ランジェリー
### セクシーランジェリー
`underwear only, lingerie, lace trim, black bra, black panties, black garter belt, black thighhighs, `  
お好みで `nipple cutout, pussy cutout, nipples, {pussy|cleft of venus}, ` 
### キャットランジェリー
`cat lingerie, cat cutout, cat ear panties, paw gloves, cat ears, cat tail, neck bell, side-tie panties, underwear, `
### 裸リボン
`naked ribbon, `
### すけすけボディースーツ
`black see-through bodystocking, shiny seamless bodystocking, see-through nipples, see-through pussy, `  
お好みで`zipper, stitch, seam, `をネガティブプロンプトに入れるとジッパーや縫い目が消えて見た目がすっきりします。

## セーター
### バックレスセーター
`virgin killer sweater, `
### バージンキラーセーター
`virgin killer sweater, cleavage cutout, pantyshot, `
### チェリーハントセーター
`virgin destroyer sweater, `
### フロントオープンセーター
`backwards virgin killer sweater, virgin killer sweater, bare shoulders, groin, naked sweater, navel, neck ribbon, stomach, `

## コスプレ
### トリック・オア・トリートメント
`florence nightingale \(trick or treatment\) \(fate\), florence nightingale \(trick or treatment\) \(fate\) \(cosplay\), `
### 酒を呑み干す童鬼の装束
`shuten douji \(fate\), shuten douji \(fate\) \(cosplay\), {open clothes| obi, obijime}, `
### デンジャラスビースト
`mash kyrielight \(dangerous beast\), mash kyrielight \(dangerous beast\) \(cosplay\), `
### ロイヤル・アイシング
`artoria pendragon \(lancer alter\) \(royal icing\) \(fate\), artoria pendragon \(lancer alter\) \(royal icing\) \(fate\) \(cosplay\), `
### ミッドナイト・サキュバス
`morrigan aensland, morrigan aensland \(cosplay\), `
### Ｃ・Ｃ・Ｃ
`\bb \(swimsuit mooncancer\) \(second ascension\) \(fate\), bb \(swimsuit mooncancer\) \(second ascension\) \(fate\) \(cosplay\), bead bracelet, belt, purple bikini, bikini under clothes, black glove, black shorts, black thighhighs, choker, fingerless gloves, hair ribbon, halterneck, long ribbon, micro shorts, navel, highleg panties, sideboob, cleavage, star hairband, {dirk skin}, `
### ユスティナ聖徒会礼装
`(alternate costume:1.2), (justina follower (blue archive):1.2), cosplay, nun, shiny clothes, skin tight, black leotard, black veil, (short veil:1.2), halo, guimpe, highleg leotard, impossible leotard, latex, latex leotard, black glove, black thighhighss, ass visible through thighs, black boots, high heel boots, `
### オルターエゴ・マリシャス
`collarbone, alternate costume, alter ego malevolent \(granblue fantasy\), goth fashion, punk, navel,  camisole, black camisole, crop top, feather boa, choker, bare shoulders, black skirt, miniskirt, thigh strap, single fishnet legwear, fishnet thighhighs, black thighhighs, boots, black boots, `
### 白いワンピース
`alternate costume,  lyria (granblue fantasy) (cosplay), white dress, jewelry, choker,  bridal gauntlets,  golden bridal gauntlets, strapless, (collarbone:0.8), (bare shoulders:0.8), thigh strap, `
### サキュバスギャル服
`<lora:s-gal-clothes:1> succubus-gal \(clothes\), collar, cardigan, navel, loose socks, demon horns, demon wings, white cardigan, demon tail, bare shoulders, (microskirt:0.7), (pubic tattoo:0.8), {convenient censoring | (pussy:0.7), nipples}, `  
https://civitai.red/models/1382150/bombergirlsuccubus-gyaruoutfit のLoraを使用しますが、それでも多少のガチャが必要
### サキュバスチアコス
`<lora:succubus0cheer:0.8>cheerleader, breast cutout, (slingshot swimsuit:0.6), navel, skirt, microskirt, lowleg skirt, demon horns, wings, low wings, `  
https://civitai.com/models/1421698/costume-succubus-cheer-bomber-girl のLoraを使用
 

# 改定記録
| 改定日 | 改定内容 | 更新者 | 
| :---: | --- |  --- | 
| 2026/10/22 | マークダウン版の作成 | 774san |
