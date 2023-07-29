INSERT INTO enum_status_translate(owner_id,language_id,column_name,translate_text)
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Соз' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),N'full_name',N'Создан')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Соз' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),N'full_name',N'Яратилди')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Соз' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),N'full_name',N'Yaratildi')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Соз' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),N'full_name',N'Created')UNION ALL

(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Соз' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),N'short_name',N'Создан')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Соз' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),N'short_name',N'Яратилди')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Соз' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),N'short_name',N'Yaratildi')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Соз' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),N'short_name',N'Created')UNION ALL
-------------
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Отп' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),N'full_name',N'Отправлен')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Отп' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),N'full_name',N'Юборилди')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Отп' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),N'full_name',N'Yuborildi')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Отп' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),N'full_name',N'Sent')UNION ALL

(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Отп' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),N'short_name',N'Отправлен')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Отп' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),N'short_name',N'Юборилди')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Отп' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),N'short_name',N'Yuborildi')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Отп' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),N'short_name',N'Sent')UNION ALL
-------------
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Прн' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),N'full_name',N'Принято')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Прн' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),N'full_name',N'Қабул қилинди')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Прн' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),N'full_name',N'Qabul qilindi')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Прн' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),N'full_name',N'Received')UNION ALL

(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Прн' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),N'short_name',N'Принято')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Прн' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),N'short_name',N'Қабул қилинди')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Прн' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),N'short_name',N'Qabul qilindi')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Прн' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),N'short_name',N'Received')UNION ALL
-------------
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Для отк' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),N'full_name',N'Для отказа')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Для отк' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),N'full_name',N'Қайтариш учун')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Для отк' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),N'full_name',N'Qaytarish uchun')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Для отк' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),N'full_name',N'For cancellation')UNION ALL

(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Для отк' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),N'short_name',N'Для отказа')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Для отк' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),N'short_name',N'Қайтариш учун')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Для отк' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),N'short_name',N'Qaytarish uchun')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Для отк' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),N'short_name',N'For cancellation')UNION ALL
-------------
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Для утвер' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),N'full_name',N'Для утверждения')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Для утвер' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),N'full_name',N'Тасдиқлаш учун')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Для утвер' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),N'full_name',N'Tasdiqlash uchun')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Для утвер' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),N'full_name',N'For acceptance')UNION ALL

(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Для утвер' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),N'short_name',N'Для утверждения')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Для утвер' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),N'short_name',N'Тасдиқлаш учун')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Для утвер' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),N'short_name',N'Tasdiqlash uchun')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Для утвер' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),N'short_name',N'For acceptance')UNION ALL
-------------
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Возв мод' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),N'full_name',N'Возврат модератору')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Возв мод' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),N'full_name',N'Модераторга қайтариш')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Возв мод' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),N'full_name',N'Moderatorga qaytarish')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Возв мод' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),N'full_name',N'Return to moderator')UNION ALL

(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Возв мод' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),N'short_name',N'Возврат модератору')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Возв мод' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),N'short_name',N'Модераторга қайтариш')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Возв мод' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),N'short_name',N'Moderatorga qaytarish')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Возв мод' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),N'short_name',N'Return to moderator')UNION ALL
-------------
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Согл' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),N'full_name',N'Согласовано')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Согл' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),N'full_name',N'Келишилди')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Согл' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),N'full_name',N'Kelishildi')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Согл' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),N'full_name',N'Agreed')UNION ALL

(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Согл' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),N'short_name',N'Согласовано')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Согл' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),N'short_name',N'Келишилди')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Согл' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),N'short_name',N'Kelishildi')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Согл' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),N'short_name',N'Agreed')UNION ALL
-------------
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Отк' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),N'full_name',N'Отказан')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Отк' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),N'full_name',N'Қайтариб юборилди')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Отк' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),N'full_name',N'Qaytarib yuborildi')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Отк' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),N'full_name',N'Denied')UNION ALL

(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Отк' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),N'short_name',N'Отказан')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Отк' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),N'short_name',N'Қайтариб юборилди')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Отк' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),N'short_name',N'Qaytarib yuborildi')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Отк' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),N'short_name',N'Denied')UNION ALL
-------------
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Арх' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),N'full_name',N'Архивный')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Арх' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),N'full_name',N'Архивланган')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Арх' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),N'full_name',N'Arxivlangan')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Арх' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),N'full_name',N'Archieved')UNION ALL

(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Арх' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),N'short_name',N'Архивный')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Арх' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),N'short_name',N'Архивланган')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Арх' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),N'short_name',N'Arxivlangan')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Арх' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),N'short_name',N'Archieved')UNION ALL
-------------
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Отз' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),N'full_name',N'Отозван')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Отз' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),N'full_name',N'Қайтариб олинди')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Отз' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),N'full_name',N'Qaytarib olindi')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Отз' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),N'full_name',N'Revoked')UNION ALL

(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Отз' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),N'short_name',N'Отозван')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Отз' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),N'short_name',N'Қайтариб олинди')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Отз' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),N'short_name',N'Qaytarib olindi')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Отз' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),N'short_name',N'Revoked')UNION ALL
-------------
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Аннул согл' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),N'full_name',N'Аннулированное соглашение')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Аннул согл' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),N'full_name',N'Бекор қилинган келишув')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Аннул согл' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),N'full_name',N'Bekor qilingan kelishuv')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Аннул согл' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),N'full_name',N'Cancelled agreement')UNION ALL

(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Аннул согл' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),N'short_name',N'Аннулированное соглашение')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Аннул согл' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),N'short_name',N'Бекор қилинган келишув')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Аннул согл' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),N'short_name',N'Bekor qilingan kelishuv')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Аннул согл' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),N'short_name',N'Cancelled agreement')UNION ALL
-------------
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Изм' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),N'full_name',N'Изменен')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Изм' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),N'full_name',N'Ўзгартирилди')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Изм' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),N'full_name',N'O‘zgartirildi')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Изм' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),N'full_name',N'Modified')UNION ALL

(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Изм' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),N'short_name',N'Изменен')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Изм' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),N'short_name',N'Ўзгартирилди')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Изм' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),N'short_name',N'O‘zgartirildi')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Изм' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),N'short_name',N'Modified')UNION ALL
-------------
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Перенос' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),N'full_name',N'Перенесенный')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Перенос' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),N'full_name',N'Кўчирилди')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Перенос' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),N'full_name',N'Ko‘chirildi')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Перенос' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),N'full_name',N'Postponed')UNION ALL

(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Перенос' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),N'short_name',N'Перенесенный')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Перенос' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),N'short_name',N'Кўчирилди')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Перенос' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),N'short_name',N'Ko‘chirildi')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Перенос' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),N'short_name',N'Postponed')UNION ALL
-------------
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Продл' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),N'full_name',N'Продлен')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Продл' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),N'full_name',N'Узайтирилди')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Продл' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),N'full_name',N'Uzaytirildi')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Продл' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),N'full_name',N'Extended')UNION ALL

(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Продл' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),N'short_name',N'Продлен')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Продл' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),N'short_name',N'Узайтирилди')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Продл' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),N'short_name',N'Uzaytirildi')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Продл' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),N'short_name',N'Extended')UNION ALL
-------------
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Отм' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),N'full_name',N'Отменено')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Отм' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),N'full_name',N'Бекор қилинди')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Отм' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),N'full_name',N'Bekor qilindi')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Отм' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),N'full_name',N'Cancelled')UNION ALL

(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Отм' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),N'short_name',N'Отменено')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Отм' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),N'short_name',N'Бекор қилинди')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Отм' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),N'short_name',N'Bekor qilindi')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Отм' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),N'short_name',N'Cancelled')UNION ALL
-------------
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Пров' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),N'full_name',N'Проведено')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Пров' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),N'full_name',N'Ўтказилди')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Пров' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),N'full_name',N'O‘tkazildi')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Пров' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),N'full_name',N'Accepted')UNION ALL

(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Пров' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),N'short_name',N'Проведено')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Пров' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),N'short_name',N'Ўтказилди')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Пров' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),N'short_name',N'O‘tkazildi')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Пров' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),N'short_name',N'Accepted')UNION ALL
-------------
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Увед' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),N'full_name',N'Уведомлен')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Увед' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),N'full_name',N'Ҳабардор қилинди')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Увед' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),N'full_name',N'Habardor qilindi')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Увед' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),N'full_name',N'Notified')UNION ALL

(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Увед' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),N'short_name',N'Уведомлен')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Увед' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),N'short_name',N'Ҳабардор қилинди')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Увед' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),N'short_name',N'Habardor qilindi')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Увед' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),N'short_name',N'Notified')UNION ALL
-------------
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Испол' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),N'full_name',N'Исполнен')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Испол' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),N'full_name',N'Бажарилди')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Испол' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),N'full_name',N'Bajarildi')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Испол' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),N'full_name',N'Fulfilled')UNION ALL

(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Испол' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),N'short_name',N'Исполнен')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Испол' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),N'short_name',N'Бажарилди')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Испол' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),N'short_name',N'Bajarildi')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE short_name=N'Испол' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),N'short_name',N'Fulfilled');
