□ERB/口上_キャラ個別ERB/224_ウルキ
	〇新規作成（アビリティ・奥義・固有特性・探索中口上）
		●奥義：『虚宿』
			・4.5倍奥義/対象の氷結Lv+1 
			・自身にダメージカット効果
			◆氷結Lv7以上の敵がいる時、次の2アビがMPと行動回数を消費しない
		●1アビ：『瞬刻水凍』
			・敵単体に水2倍ダメージ
			・味方全体の奥義ゲージアップ
			・Lv24：消費MP減少
			・Lv56：味方全体のHPを回復
		●2アビ：『氷柱槌』
			・敵全体に水8倍ダメージ/対象の氷結Lv+1
			・Lv40：消費MP減少
			・Lv72：対象にスロウ効果
		●3アビ：『蒼鏡映姿』
			・自身のHPを最大HPの20％消費し自身に全体かばう効果・弱体無効効果
			・発動時5TのCT発生
			◆このアビリティは行動回数を消費しない
			・Lv80：自身が即座に奥義発動可能
		●固有特性：『寂寞求温』
			・連撃率が低いがターン終了時に1アビが発動
			◆水属性のチェインバースト発動時、チェイン数+2

□ERB/探索/戦闘部分/戦闘メインループ（530～539行目）
	〇ウルキがメインメンバーかつ生存時、水属性CBのチェイン数を2増加するよう処理追加
		＊処理の都合上チェンバ基準キャラをウルキで設定しているので、ウルキが奥義を発動していなくてもチェンバに参加しちゃいます。ご了承下さい。

