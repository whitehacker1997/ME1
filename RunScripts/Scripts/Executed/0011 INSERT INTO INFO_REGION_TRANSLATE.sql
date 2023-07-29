INSERT INTO info_region_translate(owner_id,language_id,column_name,translate_text)
(SELECT (SELECT ID FROM info_region WHERE code=N'tash' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'short_name',N'Город Ташкент')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'tash' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'full_name',N'Город Ташкент')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'tash' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'short_name',N'Тошкент шаҳри')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'tash' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'full_name',N'Тошкент шаҳри')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'tash' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'short_name',N'Toshkent shahri')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'tash' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'full_name',N'Toshkent shahri')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'tash' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'short_name',N'Tashkent city')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'tash' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'full_name',N'Tashkent city')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'tashreg' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'short_name',N'Ташкентская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'tashreg' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'full_name',N'Ташкентская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'tashreg' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'short_name',N'Тошкент вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'tashreg' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'full_name',N'Тошкент вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'tashreg' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'short_name',N'Toshkent viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'tashreg' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'full_name',N'Toshkent viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'tashreg' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'short_name',N'Tashkent region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'tashreg' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'full_name',N'Tashkent region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'and' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'short_name',N'Андижанская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'and' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'full_name',N'Андижанская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'and' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'short_name',N'Андижон вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'and' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'full_name',N'Андижон вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'and' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'short_name',N'Andijon viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'and' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'full_name',N'Andijon viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'and' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'short_name',N'Andijon region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'and' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'full_name',N'Andijon region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'bukh' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'short_name',N'Бухарская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'bukh' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'full_name',N'Бухарская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'bukh' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'short_name',N'Бухоро вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'bukh' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'full_name',N'Бухоро вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'bukh' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'short_name',N'Buxoro viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'bukh' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'full_name',N'Buxoro viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'bukh' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'short_name',N'Bukhara region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'bukh' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'full_name',N'Bukhara region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'jiz' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'short_name',N'Джизакская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'jiz' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'full_name',N'Джизакская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'jiz' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'short_name',N'Жиззах вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'jiz' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'full_name',N'Жиззах вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'jiz' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'short_name',N'Jizzax viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'jiz' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'full_name',N'Jizzax viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'jiz' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'short_name',N'Jizzakh region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'jiz' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'full_name',N'Jizzakh region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'kk' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'short_name',N'Республика Каракалпакстан')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'kk' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'full_name',N'Республика Каракалпакстан')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'kk' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'short_name',N'Қорақалпоғистон Республикаси')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'kk' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'full_name',N'Қорақалпоғистон Республикаси')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'kk' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'short_name',N'Qoraqolpog`iston Respublikasi')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'kk' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'full_name',N'Qoraqolpog`iston Respublikasi')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'kk' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'short_name',N'Republic of Karakalpakstan')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'kk' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'full_name',N'Republic of Karakalpakstan')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'kash' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'short_name',N'Кашкадарьинская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'kash' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'full_name',N'Кашкадарьинская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'kash' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'short_name',N'Қашкадарё вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'kash' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'full_name',N'Қашкадарё вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'kash' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'short_name',N'Qashqadaryo viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'kash' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'full_name',N'Qashqadaryo viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'kash' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'short_name',N'Qashqadaryo region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'kash' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'full_name',N'Qashqadaryo region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'nav' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'short_name',N'Навоийская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'nav' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'full_name',N'Навоийская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'nav' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'short_name',N'Навоий вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'nav' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'full_name',N'Навоий вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'nav' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'short_name',N'Navoiy viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'nav' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'full_name',N'Navoiy viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'nav' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'short_name',N'Navoiy region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'nav' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'full_name',N'Navoiy region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'nam' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'short_name',N'Наманганская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'nam' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'full_name',N'Наманганская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'nam' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'short_name',N'Наманган вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'nam' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'full_name',N'Наманган вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'nam' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'short_name',N'Namangan viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'nam' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'full_name',N'Namangan viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'nam' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'short_name',N'Namangan region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'nam' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'full_name',N'Namangan region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sam' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'short_name',N'Самаркандская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sam' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'full_name',N'Самаркандская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sam' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'short_name',N'Самарқанд вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sam' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'full_name',N'Самарқанд вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sam' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'short_name',N'Samarqand viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sam' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'full_name',N'Samarqand viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sam' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'short_name',N'Samarkand region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sam' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'full_name',N'Samarkand region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sur' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'short_name',N'Сурхандарьинская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sur' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'full_name',N'Сурхандарьинская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sur' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'short_name',N'Сурхондарё вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sur' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'full_name',N'Сурхондарё вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sur' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'short_name',N'Surxandaryo viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sur' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'full_name',N'Surxandaryo viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sur' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'short_name',N'Surkhandarya region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sur' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'full_name',N'Surkhandarya region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sir' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'short_name',N'Сырдарьинская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sir' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'full_name',N'Сырдарьинская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sir' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'short_name',N'Сирдарё  вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sir' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'full_name',N'Сирдарё вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sir' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'short_name',N'Sirdaryo viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sir' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'full_name',N'Sirdaryo viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sir' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'short_name',N'Sirdaryo region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sir' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'full_name',N'Sirdaryo region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'fer' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'short_name',N'Ферганская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'fer' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'full_name',N'Ферганская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'fer' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'short_name',N'Фарғона  вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'fer' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'full_name',N'Фарғона вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'fer' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'short_name',N'Farg`ona viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'fer' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'full_name',N'Farg`ona viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'fer' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'short_name',N'Fergana region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'fer' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'full_name',N'Fergana region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'khor' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'short_name',N'Хорезмская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'khor' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'full_name',N'Хорезмская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'khor' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'short_name',N'Хоразм  вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'khor' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'full_name',N'Хоразм вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'khor' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'short_name',N'Xorazm viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'khor' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'full_name',N'Xorazm viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'khor' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'short_name',N'Khorezm region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'khor' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'full_name',N'Khorezm region');