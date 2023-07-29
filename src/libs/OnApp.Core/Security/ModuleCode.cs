using Global;

namespace OnApp.Core.Security
{
    public enum ModuleCode
    {
        #region INFO

        #region Country
        [ModuleCodeDescription(ModuleSubGroupCode.Country, "Просмотр")]
        [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
        [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
        [Translate(LanguageIdConst.RU, "Просмотр")]
        [Translate(LanguageIdConst.EN, "View")]
        CountryView,

        [ModuleCodeDescription(ModuleSubGroupCode.Country, "Создать")]
        [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
        [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
        [Translate(LanguageIdConst.RU, "Создать")]
        [Translate(LanguageIdConst.EN, "Create")]
        CountryCreate,

        [ModuleCodeDescription(ModuleSubGroupCode.Country, "Редактировать")]
        [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
        [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
        [Translate(LanguageIdConst.RU, "Редактировать")]
        [Translate(LanguageIdConst.EN, "Edit")]
        CountryEdit,

        [ModuleCodeDescription(ModuleSubGroupCode.Country, "Удалить")]
        [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
        [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
        [Translate(LanguageIdConst.RU, "Удалить")]
        [Translate(LanguageIdConst.EN, "Delete")]
        CountryDelete,
        #endregion

        #region Citizenship
        [ModuleCodeDescription(ModuleSubGroupCode.Citizenship, "Просмотр")]
        [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
        [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
        [Translate(LanguageIdConst.RU, "Просмотр")]
        [Translate(LanguageIdConst.EN, "View")]
        CitizenshipView,

        [ModuleCodeDescription(ModuleSubGroupCode.Citizenship, "Создать")]
        [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
        [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
        [Translate(LanguageIdConst.RU, "Создать")]
        [Translate(LanguageIdConst.EN, "Create")]
        CitizenshipCreate,

        [ModuleCodeDescription(ModuleSubGroupCode.Citizenship, "Редактировать")]
        [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
        [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
        [Translate(LanguageIdConst.RU, "Редактировать")]
        [Translate(LanguageIdConst.EN, "Edit")]
        CitizenshipEdit,

        [ModuleCodeDescription(ModuleSubGroupCode.Citizenship, "Удалить")]
        [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
        [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
        [Translate(LanguageIdConst.RU, "Удалить")]
        [Translate(LanguageIdConst.EN, "Delete")]
        CitizenshipDelete,
        #endregion

        #region Nationality
        [ModuleCodeDescription(ModuleSubGroupCode.Nationality, "Просмотр")]
        [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
        [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
        [Translate(LanguageIdConst.RU, "Просмотр")]
        [Translate(LanguageIdConst.EN, "View")]
        NationalityView,

        [ModuleCodeDescription(ModuleSubGroupCode.Nationality, "Создать")]
        [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
        [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
        [Translate(LanguageIdConst.RU, "Создать")]
        [Translate(LanguageIdConst.EN, "Create")]
        NationalityCreate,

        [ModuleCodeDescription(ModuleSubGroupCode.Nationality, "Редактировать")]
        [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
        [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
        [Translate(LanguageIdConst.RU, "Редактировать")]
        [Translate(LanguageIdConst.EN, "Edit")]
        NationalityEdit,

        [ModuleCodeDescription(ModuleSubGroupCode.Nationality, "Удалить")]
        [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
        [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
        [Translate(LanguageIdConst.RU, "Удалить")]
        [Translate(LanguageIdConst.EN, "Delete")]
        NationalityDelete,
        #endregion

        #region District
        [ModuleCodeDescription(ModuleSubGroupCode.District, "Просмотр")]
        [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
        [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
        [Translate(LanguageIdConst.RU, "Просмотр")]
        [Translate(LanguageIdConst.EN, "View")]
        DistrictView,

        [ModuleCodeDescription(ModuleSubGroupCode.District, "Создать")]
        [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
        [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
        [Translate(LanguageIdConst.RU, "Создать")]
        [Translate(LanguageIdConst.EN, "Create")]
        DistrictCreate,

        [ModuleCodeDescription(ModuleSubGroupCode.District, "Редактировать")]
        [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
        [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
        [Translate(LanguageIdConst.RU, "Редактировать")]
        [Translate(LanguageIdConst.EN, "Edit")]
        DistrictEdit,

        [ModuleCodeDescription(ModuleSubGroupCode.District, "Удалить")]
        [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
        [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
        [Translate(LanguageIdConst.RU, "Удалить")]
        [Translate(LanguageIdConst.EN, "Delete")]
        DistrictDelete,
        #endregion

        #region Organization
        [ModuleCodeDescription(ModuleSubGroupCode.Organization, "Просмотр")]
        [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
        [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
        [Translate(LanguageIdConst.RU, "Просмотр")]
        [Translate(LanguageIdConst.EN, "View")]
        OrganizationView,

        [ModuleCodeDescription(ModuleSubGroupCode.Organization, "Создать")]
        [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
        [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
        [Translate(LanguageIdConst.RU, "Создать")]
        [Translate(LanguageIdConst.EN, "Create")]
        OrganizationCreate,

        [ModuleCodeDescription(ModuleSubGroupCode.Organization, "Редактировать")]
        [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
        [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
        [Translate(LanguageIdConst.RU, "Редактировать")]
        [Translate(LanguageIdConst.EN, "Edit")]
        OrganizationEdit,

        [ModuleCodeDescription(ModuleSubGroupCode.Organization, "Удалить")]
        [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
        [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
        [Translate(LanguageIdConst.RU, "Удалить")]
        [Translate(LanguageIdConst.EN, "Delete")]
        OrganizationDelete,
        #endregion

        #region Region
        [ModuleCodeDescription(ModuleSubGroupCode.Region, "Просмотр")]
        [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
        [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
        [Translate(LanguageIdConst.RU, "Просмотр")]
        [Translate(LanguageIdConst.EN, "View")]
        RegionView,

        [ModuleCodeDescription(ModuleSubGroupCode.Region, "Создать")]
        [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
        [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
        [Translate(LanguageIdConst.RU, "Создать")]
        [Translate(LanguageIdConst.EN, "Create")]
        RegionCreate,

        [ModuleCodeDescription(ModuleSubGroupCode.Region, "Редактировать")]
        [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
        [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
        [Translate(LanguageIdConst.RU, "Редактировать")]
        [Translate(LanguageIdConst.EN, "Edit")]
        RegionEdit,

        [ModuleCodeDescription(ModuleSubGroupCode.Region, "Удалить")]
        [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
        [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
        [Translate(LanguageIdConst.RU, "Удалить")]
        [Translate(LanguageIdConst.EN, "Delete")]
        RegionDelete,
        #endregion

        #endregion

        #region HL
        #region Subject
        [ModuleCodeDescription(ModuleSubGroupCode.Subject, "Просмотр")]
        [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
        [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
        [Translate(LanguageIdConst.RU, "Просмотр")]
        [Translate(LanguageIdConst.EN, "View")]
        SubjectView,

        [ModuleCodeDescription(ModuleSubGroupCode.Subject, "Создать")]
        [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
        [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
        [Translate(LanguageIdConst.RU, "Создать")]
        [Translate(LanguageIdConst.EN, "Create")]
        SubjectCreate,

        [ModuleCodeDescription(ModuleSubGroupCode.Subject, "Редактировать")]
        [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
        [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
        [Translate(LanguageIdConst.RU, "Редактировать")]
        [Translate(LanguageIdConst.EN, "Edit")]
        SubjectEdit,

        [ModuleCodeDescription(ModuleSubGroupCode.Subject, "Удалить")]
        [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
        [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
        [Translate(LanguageIdConst.RU, "Удалить")]
        [Translate(LanguageIdConst.EN, "Delete")]
        SubjectDelete,
        #endregion

        #region Group
        [ModuleCodeDescription(ModuleSubGroupCode.Group, "Просмотр")]
        [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
        [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
        [Translate(LanguageIdConst.RU, "Просмотр")]
        [Translate(LanguageIdConst.EN, "View")]
        GroupView,

        [ModuleCodeDescription(ModuleSubGroupCode.Group, "Создать")]
        [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
        [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
        [Translate(LanguageIdConst.RU, "Создать")]
        [Translate(LanguageIdConst.EN, "Create")]
        GroupCreate,

        [ModuleCodeDescription(ModuleSubGroupCode.Group, "Редактировать")]
        [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
        [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
        [Translate(LanguageIdConst.RU, "Редактировать")]
        [Translate(LanguageIdConst.EN, "Edit")]
        GroupEdit,

        [ModuleCodeDescription(ModuleSubGroupCode.Group, "Удалить")]
        [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
        [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
        [Translate(LanguageIdConst.RU, "Удалить")]
        [Translate(LanguageIdConst.EN, "Delete")]
        GroupDelete,
        #endregion

        #region Room
        [ModuleCodeDescription(ModuleSubGroupCode.Room, "Просмотр")]
        [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
        [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
        [Translate(LanguageIdConst.RU, "Просмотр")]
        [Translate(LanguageIdConst.EN, "View")]
        RoomView,

        [ModuleCodeDescription(ModuleSubGroupCode.Room, "Создать")]
        [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
        [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
        [Translate(LanguageIdConst.RU, "Создать")]
        [Translate(LanguageIdConst.EN, "Create")]
        RoomCreate,

        [ModuleCodeDescription(ModuleSubGroupCode.Room, "Редактировать")]
        [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
        [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
        [Translate(LanguageIdConst.RU, "Редактировать")]
        [Translate(LanguageIdConst.EN, "Edit")]
        RoomEdit,

        [ModuleCodeDescription(ModuleSubGroupCode.Room, "Удалить")]
        [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
        [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
        [Translate(LanguageIdConst.RU, "Удалить")]
        [Translate(LanguageIdConst.EN, "Delete")]
        RoomDelete,
        #endregion
        #region Person
        [ModuleCodeDescription(ModuleSubGroupCode.Person, "Просмотр")]
        [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
        [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
        [Translate(LanguageIdConst.RU, "Просмотр")]
        [Translate(LanguageIdConst.EN, "View")]
        PersonView,

        [ModuleCodeDescription(ModuleSubGroupCode.Person, "Создать")]
        [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
        [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
        [Translate(LanguageIdConst.RU, "Создать")]
        [Translate(LanguageIdConst.EN, "Create")]
        PersonCreate,

        [ModuleCodeDescription(ModuleSubGroupCode.Person, "Редактировать")]
        [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
        [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
        [Translate(LanguageIdConst.RU, "Редактировать")]
        [Translate(LanguageIdConst.EN, "Edit")]
        PersonEdit,

        [ModuleCodeDescription(ModuleSubGroupCode.Person, "Удалить")]
        [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
        [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
        [Translate(LanguageIdConst.RU, "Удалить")]
        [Translate(LanguageIdConst.EN, "Delete")]
        PersonDelete,
        #endregion

        #region Employee
        [ModuleCodeDescription(ModuleSubGroupCode.Employee, "Просмотр")]
        [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
        [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
        [Translate(LanguageIdConst.RU, "Просмотр")]
        [Translate(LanguageIdConst.EN, "View")]
        EmployeeView,

        [ModuleCodeDescription(ModuleSubGroupCode.Employee, "Создать")]
        [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
        [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
        [Translate(LanguageIdConst.RU, "Создать")]
        [Translate(LanguageIdConst.EN, "Create")]
        EmployeeCreate,

        [ModuleCodeDescription(ModuleSubGroupCode.Employee, "Редактировать")]
        [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
        [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
        [Translate(LanguageIdConst.RU, "Редактировать")]
        [Translate(LanguageIdConst.EN, "Edit")]
        EmployeeEdit,

        [ModuleCodeDescription(ModuleSubGroupCode.Employee, "Удалить")]
        [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
        [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
        [Translate(LanguageIdConst.RU, "Удалить")]
        [Translate(LanguageIdConst.EN, "Delete")]
        EmployeeDelete,
        #endregion

        #region Student
        [ModuleCodeDescription(ModuleSubGroupCode.Student, "Просмотр")]
        [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
        [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
        [Translate(LanguageIdConst.RU, "Просмотр")]
        [Translate(LanguageIdConst.EN, "View")]
        StudentView,

        [ModuleCodeDescription(ModuleSubGroupCode.Student, "Создать")]
        [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
        [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
        [Translate(LanguageIdConst.RU, "Создать")]
        [Translate(LanguageIdConst.EN, "Create")]
        StudentCreate,

        [ModuleCodeDescription(ModuleSubGroupCode.Student, "Редактировать")]
        [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
        [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
        [Translate(LanguageIdConst.RU, "Редактировать")]
        [Translate(LanguageIdConst.EN, "Edit")]
        StudentEdit,

        [ModuleCodeDescription(ModuleSubGroupCode.Student, "Удалить")]
        [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
        [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
        [Translate(LanguageIdConst.RU, "Удалить")]
        [Translate(LanguageIdConst.EN, "Delete")]
        StudentDelete,
        #endregion

        #region Position
        [ModuleCodeDescription(ModuleSubGroupCode.Position, "Просмотр")]
        [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
        [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
        [Translate(LanguageIdConst.RU, "Просмотр")]
        [Translate(LanguageIdConst.EN, "View")]
        PositionView,

        [ModuleCodeDescription(ModuleSubGroupCode.Position, "Создать")]
        [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
        [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
        [Translate(LanguageIdConst.RU, "Создать")]
        [Translate(LanguageIdConst.EN, "Create")]
        PositionCreate,

        [ModuleCodeDescription(ModuleSubGroupCode.Position, "Редактировать")]
        [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
        [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
        [Translate(LanguageIdConst.RU, "Редактировать")]
        [Translate(LanguageIdConst.EN, "Edit")]
        PositionEdit,

        [ModuleCodeDescription(ModuleSubGroupCode.Position, "Удалить")]
        [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
        [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
        [Translate(LanguageIdConst.RU, "Удалить")]
        [Translate(LanguageIdConst.EN, "Delete")]
        PositionDelete,
        #endregion

        #endregion

        #region DOC

        #endregion
        #region SYS

        #region Role
        [ModuleCodeDescription(ModuleSubGroupCode.Role, "Просмотр")]
        [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
        [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
        [Translate(LanguageIdConst.RU, "Просмотр")]
        [Translate(LanguageIdConst.EN, "View")]
        RoleView,

        [ModuleCodeDescription(ModuleSubGroupCode.Role, "Создать")]
        [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
        [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
        [Translate(LanguageIdConst.RU, "Создать")]
        [Translate(LanguageIdConst.EN, "Create")]
        RoleCreate,

        [ModuleCodeDescription(ModuleSubGroupCode.Role, "Редактировать")]
        [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
        [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
        [Translate(LanguageIdConst.RU, "Редактировать")]
        [Translate(LanguageIdConst.EN, "Edit")]
        RoleEdit,

        [ModuleCodeDescription(ModuleSubGroupCode.Role, "Удалить")]
        [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
        [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
        [Translate(LanguageIdConst.RU, "Удалить")]
        [Translate(LanguageIdConst.EN, "Delete")]
        RoleDelete,
        #endregion

        #region User
        [ModuleCodeDescription(ModuleSubGroupCode.User, "Просмотр")]
        [Translate(LanguageIdConst.UZ_CYRL, "Кўриш")]
        [Translate(LanguageIdConst.UZ_LATN, "Ko'rish")]
        [Translate(LanguageIdConst.RU, "Просмотр")]
        [Translate(LanguageIdConst.EN, "View")]
        UserView,

        [ModuleCodeDescription(ModuleSubGroupCode.User, "Создать")]
        [Translate(LanguageIdConst.UZ_CYRL, "Яратиш")]
        [Translate(LanguageIdConst.UZ_LATN, "Yaratish")]
        [Translate(LanguageIdConst.RU, "Создать")]
        [Translate(LanguageIdConst.EN, "Create")]
        UserCreate,

        [ModuleCodeDescription(ModuleSubGroupCode.User, "Редактировать")]
        [Translate(LanguageIdConst.UZ_CYRL, "Таҳрирлаш")]
        [Translate(LanguageIdConst.UZ_LATN, "Tahrirlash")]
        [Translate(LanguageIdConst.RU, "Редактировать")]
        [Translate(LanguageIdConst.EN, "Edit")]
        UserEdit,

        [ModuleCodeDescription(ModuleSubGroupCode.User, "Удалить")]
        [Translate(LanguageIdConst.UZ_CYRL, "Ўчириш")]
        [Translate(LanguageIdConst.UZ_LATN, "O'chirish")]
        [Translate(LanguageIdConst.RU, "Удалить")]
        [Translate(LanguageIdConst.EN, "Delete")]
        UserDelete,

        [ModuleCodeDescription(ModuleSubGroupCode.User, "Просмотр по подразделениям")]
        [Translate(LanguageIdConst.UZ_CYRL, "Бўлимлар бўйича кўриш")]
        [Translate(LanguageIdConst.UZ_LATN, "Bo'limlar bo'yicha ko'rish")]
        [Translate(LanguageIdConst.RU, "Просмотр по подразделениям")]
        [Translate(LanguageIdConst.EN, "View by branches")]
        BranchesUserView,

        [ModuleCodeDescription(ModuleSubGroupCode.User, "Создать по подразделениям")]
        [Translate(LanguageIdConst.UZ_CYRL, "Бўлимлар бўйича яратиш")]
        [Translate(LanguageIdConst.UZ_LATN, "Bo'limlar bo'yicha yaratish")]
        [Translate(LanguageIdConst.RU, "Создать по подразделениям")]
        [Translate(LanguageIdConst.EN, "Create by branches")]
        BranchesUserCreate,

        [ModuleCodeDescription(ModuleSubGroupCode.User, "Редактировать по подразделениям")]
        [Translate(LanguageIdConst.UZ_CYRL, "Бўлимлар бўйича таҳрирлаш")]
        [Translate(LanguageIdConst.UZ_LATN, "Bo'limlar bo'yicha tahrirlash")]
        [Translate(LanguageIdConst.RU, "Редактировать по подразделениям")]
        [Translate(LanguageIdConst.EN, "Edit by branches")]
        BranchesUserEdit,

        [ModuleCodeDescription(ModuleSubGroupCode.User, "Удалить по подразделениям")]
        [Translate(LanguageIdConst.UZ_CYRL, "Бўлимлар бўйича ўчириш")]
        [Translate(LanguageIdConst.UZ_LATN, "Bo'limlar bo'yicha o'chirish")]
        [Translate(LanguageIdConst.RU, "Удалить по подразделениям")]
        [Translate(LanguageIdConst.EN, "Delete by branches")]
        BranchesUserDelete,

        [ModuleCodeDescription(ModuleSubGroupCode.User, "Просмотр все")]
        [Translate(LanguageIdConst.UZ_CYRL, "Барчасини кўриш")]
        [Translate(LanguageIdConst.UZ_LATN, "Barchasini ko'rish")]
        [Translate(LanguageIdConst.RU, "Просмотр все")]
        [Translate(LanguageIdConst.EN, "View all")]
        AllUserView,

        [ModuleCodeDescription(ModuleSubGroupCode.User, "Создать все")]
        [Translate(LanguageIdConst.UZ_CYRL, "Барчасини яратиш")]
        [Translate(LanguageIdConst.UZ_LATN, "Barchasini yaratish")]
        [Translate(LanguageIdConst.RU, "Создать все")]
        [Translate(LanguageIdConst.EN, "Create all")]
        AllUserCreate,

        [ModuleCodeDescription(ModuleSubGroupCode.User, "Редактировать все")]
        [Translate(LanguageIdConst.UZ_CYRL, "Барчасини таҳрирлаш")]
        [Translate(LanguageIdConst.UZ_LATN, "Barchasini tahrirlash")]
        [Translate(LanguageIdConst.RU, "Редактировать все")]
        [Translate(LanguageIdConst.EN, "Edit all")]
        AllUserEdit,

        [ModuleCodeDescription(ModuleSubGroupCode.User, "Удалить все")]
        [Translate(LanguageIdConst.UZ_CYRL, "Барчасини ўчириш")]
        [Translate(LanguageIdConst.UZ_LATN, "Barchasini o'chirish")]
        [Translate(LanguageIdConst.RU, "Удалить все")]
        [Translate(LanguageIdConst.EN, "Delete all")]
        AllUserDelete,
        #endregion
        #endregion
    }
}
