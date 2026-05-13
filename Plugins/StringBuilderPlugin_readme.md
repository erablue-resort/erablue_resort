# StringBuilderPlugin

ERBからStringBuilderを使えるようにするプラグイン
以下の例のように、文字列変数に何度も追記する書き方はそのたびに新しい文字列が作成されるためメモリコストが大きい
2～5回程度ならそのまま連結するほうがよいが、大量の追記をする場合はStringBuilderを使うとメモリ消費量や計算速度を改善できる…カモ

```
VARS '= "hello"
VARS += ", "
VARS += "world"
VARS += "!"
```


## `SB_CREATE(str name[, int initialCapacity])`

新しいStringBuilder `name` を作成する。

`name` で紐づいたStringBuilderが既に存在する場合は作成がスキップされるが、この関数単体ではこの挙動を検知することができない。  
StringBuilderの存在が事前に知りたいなら `SB_EXIST` を、常に新規のStringBuilderを作成したいだけなら `SB_RELEASE` を使用すること。  
(詳細はそれぞれの関数の説明を参照)

省略可能パラメータ `initialCapacity` でStringBuilderの初期容量を変更可能。  
適切に中身を設定すれば更なるメモリ消費量や計算速度の改善が見込めるが、わかる人のみ触ることを推奨。


## `SB_EXIST(str name, intRef result)`

StringBuilder `name` が既に存在する場合は1、存在しない場合は0を数値型変数 `result` に代入する。


## `SB_RELEASE(str name)`

StringBuilder `name` が存在すれば削除する。

StringBuilder `name` が存在しなくてもエラーは発生しないので、事前に `SB_EXIST` と `IF` を用いて回避するコードは不要。


## `SB_RESET()`

全てのStringBuilderを削除する。


## `SB_APPEND(str name, str text)`

StringBuilder `name` に文字列 `text` を追記する。


## `SB_APPENDL(str name[, str text])`

StringBuilder `name` に文字列 `text` を追記し、改行する。改行コードは `\r\n`。

文字列 `text` は省略可能。その場合、改行のみ行う。


## `SB_TOSTR(str name, strRef result)`

StringBuilder `name` を文字列に変換し、文字列変数 `result` に代入する。


## `SB_CLEAR(str name)`

StringBuilder `name` の中身を空にする。StringBuilder自体は削除されない。  
INPUTループなどで同じStringBuilderを再利用する場合にどうぞ。

