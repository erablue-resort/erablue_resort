;_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/#
;パッチ名：CSVエディタ修正パッチ
;作者：
;作成日：2024/11/8
;
;作成内容の概要：
;　・特殊種族名の入出力に対応
;　・同行候補キャラ表示に「NAME表示省略」関数が使用されていなかったのを修正
;　・設定項目の「名前」「二つ名」「呼び名」「出演作品」について、
;　　入力が全角12文字をオーバーした際に省略した旨を表示するように変更
;　・CSV出力時のプレゼント好みに関するコメントの一部が更新されていなかったのを修正
;
;　・「NAME表示省略」関数で省略後の名前に半角文字が奇数個含まれている場合に
;　　長さ41で返していたのを長さ39で返すように修正
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
