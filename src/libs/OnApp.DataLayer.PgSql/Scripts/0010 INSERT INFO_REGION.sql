insert into info_region (code, soato, roaming_code, short_name, full_name, order_code, state_id, country_id)
(SELECT N'tash', N'1726', N'26', N'Город Ташкент',N'Город Ташкент',N'01', 1, id FROM info_country where text_code = 'UZB' limit 1)
UNION ALL
(SELECT N'tashreg', N'1727', N'27', N'Ташкентская',N'Ташкентская',N'02',1, id FROM info_country where text_code = 'UZB' limit 1)
UNION ALL
(SELECT N'and', N'1703', N'3', N'Андижанская',N'Андижанская',N'03',1, id FROM info_country where text_code = 'UZB' limit 1)
UNION ALL
(SELECT N'bukh', N'1706', N'6', N'Бухарская',N'Бухарская',N'04',1, id FROM info_country where text_code = 'UZB' limit 1)
UNION ALL
(SELECT N'jiz', N'1708', N'8', N'Джизакская',N'Джизакская',N'05',1, id FROM info_country where text_code = 'UZB' limit 1)
UNION ALL
(SELECT N'kk', N'1735', N'35', N'Республика Каракалпакстан',N'Республика Каракалпакстан',N'06',1, id FROM info_country where text_code = 'UZB' limit 1)
UNION ALL
(SELECT N'kash', N'1710', N'10', N'Кашкадарьинская',N'Кашкадарьинская',N'07',1, id FROM info_country where text_code = 'UZB' limit 1)
UNION ALL
(SELECT N'nav', N'1712', N'12', N'Навоийская',N'Навоийская',N'08',1, id FROM info_country where text_code = 'UZB' limit 1)
UNION ALL
(SELECT N'nam', N'1714', N'14', N'Наманганская',N'Наманганская',N'09',1, id FROM info_country where text_code = 'UZB' limit 1)
UNION ALL
(SELECT N'sam', N'1718', N'18', N'Самаркандская',N'Самаркандская',N'10',1, id FROM info_country where text_code = 'UZB' limit 1)
UNION ALL
(SELECT N'sur', N'1722', N'22', N'Сурхандарьинская',N'Сурхандарьинская',N'11',1, id FROM info_country where text_code = 'UZB' limit 1)
UNION ALL
(SELECT N'sir', N'1724', N'24', N'Сырдарьинская',N'Сырдарьинская',N'12',1, id FROM info_country where text_code = 'UZB' limit 1)
UNION ALL
(SELECT N'fer', N'1730', N'30', N'Ферганская',N'Ферганская',N'13',1, id FROM info_country where text_code = 'UZB' limit 1)
UNION ALL
(SELECT N'khor', N'1733', N'33', N'Хорезмская',N'Хорезмская',N'14',1, id FROM info_country where text_code = 'UZB' limit 1);