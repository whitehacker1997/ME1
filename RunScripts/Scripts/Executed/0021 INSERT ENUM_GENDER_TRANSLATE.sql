INSERT INTO enum_gender_translate(owner_id,language_id,column_name,translate_text)
(SELECT (SELECT ID FROM enum_state WHERE ID=1 limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),N'short_name',N'Мужчина')UNION ALL
(SELECT (SELECT ID FROM enum_state WHERE ID=1 limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),N'full_name',N'Мужчина')UNION ALL
(SELECT (SELECT ID FROM enum_state WHERE ID=1 limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),N'short_name',N'Эркак')UNION ALL
(SELECT (SELECT ID FROM enum_state WHERE ID=1 limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),N'full_name',N'Эркак')UNION ALL
(SELECT (SELECT ID FROM enum_state WHERE ID=1 limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),N'short_name',N'Erkak')UNION ALL
(SELECT (SELECT ID FROM enum_state WHERE ID=1 limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),N'full_name',N'Erkak')UNION ALL
(SELECT (SELECT ID FROM enum_state WHERE ID=1 limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),N'short_name',N'Male')UNION ALL
(SELECT (SELECT ID FROM enum_state WHERE ID=1 limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),N'full_name',N'Male')UNION ALL
(SELECT (SELECT ID FROM enum_state WHERE ID=2 limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),N'short_name',N'Женщина')UNION ALL
(SELECT (SELECT ID FROM enum_state WHERE ID=2 limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),N'full_name',N'Женщина')UNION ALL
(SELECT (SELECT ID FROM enum_state WHERE ID=2 limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),N'short_name',N'Аёл')UNION ALL
(SELECT (SELECT ID FROM enum_state WHERE ID=2 limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),N'full_name',N'Аёл')UNION ALL
(SELECT (SELECT ID FROM enum_state WHERE ID=2 limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),N'short_name',N'Ayol')UNION ALL
(SELECT (SELECT ID FROM enum_state WHERE ID=2 limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),N'full_name',N'Ayol')UNION ALL
(SELECT (SELECT ID FROM enum_state WHERE ID=2 limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),N'short_name',N'Female')UNION ALL
(SELECT (SELECT ID FROM enum_state WHERE ID=2 limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),N'full_name',N'Female');