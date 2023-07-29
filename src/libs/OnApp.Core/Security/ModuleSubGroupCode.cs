using Global;

namespace OnApp.Core.Security
{
    public enum ModuleSubGroupCode
    {
        #region INFO
        [ModuleSubGroupDescription(ModuleGroupIdConst.MANUALS, "Страна")]
        [Translate(LanguageIdConst.UZ_CYRL, "Давлат")]
        [Translate(LanguageIdConst.UZ_LATN, "Davlat")]
        [Translate(LanguageIdConst.RU, "Страна")]
        [Translate(LanguageIdConst.EN, "Country")]
        Country,

        [ModuleSubGroupDescription(ModuleGroupIdConst.MANUALS, "Гражданство")]
        [Translate(LanguageIdConst.UZ_CYRL, "Фукоролик")]
        [Translate(LanguageIdConst.UZ_LATN, "Fuqorolik")]
        [Translate(LanguageIdConst.RU, "Гражданство")]
        [Translate(LanguageIdConst.EN, "Citizenship")]
        Citizenship,

        [ModuleSubGroupDescription(ModuleGroupIdConst.MANUALS, "Национальность")]
        [Translate(LanguageIdConst.UZ_CYRL, "Миллати")]
        [Translate(LanguageIdConst.UZ_LATN, "Millati")]
        [Translate(LanguageIdConst.RU, "Национальность")]
        [Translate(LanguageIdConst.EN, "Nationality")]
        Nationality,

        [ModuleSubGroupDescription(ModuleGroupIdConst.MANUALS, "Район")]
        [Translate(LanguageIdConst.UZ_CYRL, "Туман")]
        [Translate(LanguageIdConst.UZ_LATN, "Tuman")]
        [Translate(LanguageIdConst.RU, "Район")]
        [Translate(LanguageIdConst.EN, "District")]
        District,


        [ModuleSubGroupDescription(ModuleGroupIdConst.MANUALS, "Организация")]
        [Translate(LanguageIdConst.UZ_CYRL, "Ташкилот")]
        [Translate(LanguageIdConst.UZ_LATN, "Tashkilot")]
        [Translate(LanguageIdConst.RU, "Организация")]
        [Translate(LanguageIdConst.EN, "Organization")]
        Organization,

        [ModuleSubGroupDescription(ModuleGroupIdConst.MANUALS, "Область")]
        [Translate(LanguageIdConst.UZ_CYRL, "Вилоят")]
        [Translate(LanguageIdConst.UZ_LATN, "Viloyat")]
        [Translate(LanguageIdConst.RU, "Область")]
        [Translate(LanguageIdConst.EN, "Region")]
        Region,

        #endregion

        #region HL

        [ModuleSubGroupDescription(ModuleGroupIdConst.MANUALS, "Позиция")]
        [Translate(LanguageIdConst.UZ_CYRL, "Лавозим")]
        [Translate(LanguageIdConst.UZ_LATN, "Lavozim")]
        [Translate(LanguageIdConst.RU, "Позиция")]
        [Translate(LanguageIdConst.EN, "Position")]
        Position,

        [ModuleSubGroupDescription(ModuleGroupIdConst.MANUALS, "Предмет")]
        [Translate(LanguageIdConst.UZ_CYRL, "Фан")]
        [Translate(LanguageIdConst.UZ_LATN, "Fan")]
        [Translate(LanguageIdConst.RU, "Предмет")]
        [Translate(LanguageIdConst.EN, "Subject")]
        Subject,

        [ModuleSubGroupDescription(ModuleGroupIdConst.MANUALS, "Группа")]
        [Translate(LanguageIdConst.UZ_CYRL, "Гурух")]
        [Translate(LanguageIdConst.UZ_LATN, "Guruh")]
        [Translate(LanguageIdConst.RU, "Группа")]
        [Translate(LanguageIdConst.EN, "Group")]
        Group,

        [ModuleSubGroupDescription(ModuleGroupIdConst.MANUALS, "Комната")]
        [Translate(LanguageIdConst.UZ_CYRL, "Хона")]
        [Translate(LanguageIdConst.UZ_LATN, "Xona")]
        [Translate(LanguageIdConst.RU, "Комната")]
        [Translate(LanguageIdConst.EN, "Room")]
        Room,

        [ModuleSubGroupDescription(ModuleGroupIdConst.MANUALS, "Персона")]
        [Translate(LanguageIdConst.UZ_CYRL, "Шахс")]
        [Translate(LanguageIdConst.UZ_LATN, "Shaxs")]
        [Translate(LanguageIdConst.RU, "Персона")]
        [Translate(LanguageIdConst.EN, "Person")]
        Person,

        [ModuleSubGroupDescription(ModuleGroupIdConst.MANUALS, "Сотрудник")]
        [Translate(LanguageIdConst.UZ_CYRL, "Ходим")]
        [Translate(LanguageIdConst.UZ_LATN, "Xodim")]
        [Translate(LanguageIdConst.RU, "Сотрудник")]
        [Translate(LanguageIdConst.EN, "Employee")]
        Employee,


        [ModuleSubGroupDescription(ModuleGroupIdConst.MANUALS, "Студент")]
        [Translate(LanguageIdConst.UZ_CYRL, "Талаба")]
        [Translate(LanguageIdConst.UZ_LATN, "Talaba")]
        [Translate(LanguageIdConst.RU, "Студент")]
        [Translate(LanguageIdConst.EN, "Student")]
        Student,
        #endregion

        #region DOC

        #endregion

        #region SYS

        [ModuleSubGroupDescription(ModuleGroupIdConst.MANUALS, "Роль")]
        [Translate(LanguageIdConst.UZ_CYRL, "Роль")]
        [Translate(LanguageIdConst.UZ_LATN, "Rol")]
        [Translate(LanguageIdConst.RU, "Роль")]
        [Translate(LanguageIdConst.EN, "Role")]
        Role,

        [ModuleSubGroupDescription(ModuleGroupIdConst.MANUALS, "Пользователь")]
        [Translate(LanguageIdConst.UZ_CYRL, "Фойдаланувчи")]
        [Translate(LanguageIdConst.UZ_LATN, "Foydalanuvchi")]
        [Translate(LanguageIdConst.RU, "Пользователь")]
        [Translate(LanguageIdConst.EN, "User")]
        User,
        #endregion
    }
}
