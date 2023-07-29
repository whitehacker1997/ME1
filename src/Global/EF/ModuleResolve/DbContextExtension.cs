using Microsoft.EntityFrameworkCore;

namespace Global.EF
{
    public static class DbContextExtension
    {
        public static void ResolveModules<TModuleCodeEnum,
                                          TModule,
                                          TModuleTranslate,
                                          TModuleSubGroup,
                                          TModuleSubGroupTranslate>(this DbContext context)
                                                where TModuleCodeEnum : struct
                                                where TModule : class,
                                                                IModule<TModuleTranslate,
                                                                        TModuleSubGroup,
                                                                        TModuleSubGroupTranslate>,
                                                                new()
                                                where TModuleTranslate : class,
                                                                         ITranslate,
                                                                         new()
                                                where TModuleSubGroup : class,
                                                                        IModuleSubGroup<TModuleSubGroupTranslate>,
                                                                        new()
                                                where TModuleSubGroupTranslate : class,
                                                                                 ITranslate,
                                                                                 new()
        {
            var moduleSubGroupList = context.Set<TModuleSubGroup>()
                                            .Include(moduleSubGroup => moduleSubGroup.Translates)
                                                .ToList();

            var moduleList = context.Set<TModule>()
                                    .Include(module => module.SubGroup)
                                    .Include(module => module.Translates)
                                        .ToList();

            var subGroupDescs = ModuleCodeHelper.GetDescriptions<TModuleCodeEnum>();

            foreach (KeyValuePair<string, ModuleSubGroupDescription> subGroupDesc in subGroupDescs)
            {
                TModuleSubGroup moduleSubGroup
                    = moduleSubGroupList.
                        FirstOrDefault(moduleSubGroup => subGroupDesc.Key == moduleSubGroup.Code);

                if (moduleSubGroup == null)
                {
                    moduleSubGroup
                        = new TModuleSubGroup
                        {
                            Code = subGroupDesc.Key,
                            ShortName = subGroupDesc.Value.ShortName,
                            FullName = subGroupDesc.Value.FullName,
                            GroupId = subGroupDesc.Value.ModuleGroupId
                        };

                    moduleSubGroupList.Add(moduleSubGroup);

                    context.Set<TModuleSubGroup>().Add(moduleSubGroup);

                    context.Entry(moduleSubGroup).State
                                                    = EntityState.Added;

                    foreach (var translate in subGroupDesc.Value.Translates)
                    {
                        TModuleSubGroupTranslate moduleSubGroupTranslate
                            = new TModuleSubGroupTranslate
                            {
                                ColumnName = translate.ShortNameColumnName,
                                LanguageId = translate.LanguageId,
                                TranslateText = translate.ShortName
                            };

                        moduleSubGroup.Translates.Add(moduleSubGroupTranslate);

                        context.Set<TModuleSubGroupTranslate>()
                               .Add(moduleSubGroupTranslate);

                        context.Entry(moduleSubGroupTranslate).State
                                                                = EntityState.Added;

                        moduleSubGroupTranslate = new TModuleSubGroupTranslate
                        {
                            ColumnName = translate.FullNameColumnName,
                            LanguageId = translate.LanguageId,
                            TranslateText = translate.FullName
                        };

                        moduleSubGroup.Translates.Add(moduleSubGroupTranslate);

                        context.Set<TModuleSubGroupTranslate>()
                               .Add(moduleSubGroupTranslate);

                        context.Entry(moduleSubGroupTranslate).State
                                                                = EntityState.Added;
                    }
                }
                else
                {
                    if (
                        moduleSubGroup.ShortName != subGroupDesc.Value.ShortName ||
                        moduleSubGroup.FullName != subGroupDesc.Value.FullName ||
                        moduleSubGroup.GroupId != subGroupDesc.Value.ModuleGroupId)
                    {
                        moduleSubGroup.ShortName = subGroupDesc.Value.ShortName;
                        moduleSubGroup.FullName = subGroupDesc.Value.FullName;
                        moduleSubGroup.GroupId = subGroupDesc.Value.ModuleGroupId;

                        context.Entry(moduleSubGroup).State
                                                        = EntityState.Modified;
                    }

                    foreach (var translateDescription2 in subGroupDesc.Value.Translates)
                    {
                        var val3
                            = moduleSubGroup.Translates
                                .FirstOrDefault(moduleSubGroupTranslate =>
                                                        moduleSubGroupTranslate.LanguageId == translateDescription2.LanguageId &&
                                                        moduleSubGroupTranslate.ColumnName == translateDescription2.ShortNameColumnName);

                        if (val3 == null)
                            moduleSubGroup.Translates.Add(
                                new TModuleSubGroupTranslate
                                {
                                    ColumnName = translateDescription2.ShortNameColumnName,
                                    LanguageId = translateDescription2.LanguageId,
                                    TranslateText = translateDescription2.ShortName
                                });
                        else if (val3.TranslateText != translateDescription2.ShortName)
                        {
                            val3.TranslateText = translateDescription2.ShortName;
                            context.Entry(val3).State = EntityState.Modified;
                        }

                        var val4
                                = moduleSubGroup.Translates
                                .FirstOrDefault(moduleSubGroupTranslate =>
                                                        moduleSubGroupTranslate.LanguageId == translateDescription2.LanguageId &&
                                                        moduleSubGroupTranslate.ColumnName == translateDescription2.FullNameColumnName);

                        if (val4 == null)
                            moduleSubGroup.Translates.Add(new TModuleSubGroupTranslate
                            {
                                ColumnName = translateDescription2.FullNameColumnName,
                                LanguageId = translateDescription2.LanguageId,
                                TranslateText = translateDescription2.FullName
                            });
                        else if (val4.TranslateText != translateDescription2.FullName)
                        {
                            val4.TranslateText = translateDescription2.FullName;
                            context.Entry(val4).State = EntityState.Modified;
                        }
                    }
                    var moduleSubGroupTranslates
                            = moduleSubGroup.Translates
                                .Where(moduleSubGroupTranslate => !subGroupDesc.Value.Translates.Any(translateDescription => moduleSubGroupTranslate.LanguageId == translateDescription.LanguageId &&
                                    (moduleSubGroupTranslate.ColumnName == translateDescription.ShortNameColumnName || moduleSubGroupTranslate.ColumnName == translateDescription.FullNameColumnName)));

                    foreach (var item in moduleSubGroupTranslates)
                        context.Entry(item).State = EntityState.Deleted;
                }

                foreach (var moduleDesc in subGroupDesc.Value.ModuleCodes)
                {
                    TModule val5
                                = moduleList.FirstOrDefault(module => module.Code == moduleDesc.Code);

                    if (val5 == null)
                    {
                        val5 = new TModule
                        {
                            Code = moduleDesc.Code,
                            ShortName = moduleDesc.ShortName,
                            FullName = moduleDesc.FullName,
                            SubGroup = moduleSubGroup
                        };

                        moduleList.Add(val5);

                        context.Set<TModule>().Add(val5);
                        context.Entry(val5).State = EntityState.Added;

                        foreach (var translate2 in moduleDesc.Translates)
                        {
                            TModuleTranslate val6
                                = new TModuleTranslate
                                {
                                    ColumnName = translate2.ShortNameColumnName,
                                    LanguageId = translate2.LanguageId,
                                    TranslateText = translate2.ShortName
                                };
                            val5.Translates.Add(val6);
                            context.Set<TModuleTranslate>().Add(val6);
                            context.Entry(val6).State = EntityState.Added;
                            val6 = new TModuleTranslate
                            {
                                ColumnName = translate2.FullNameColumnName,
                                LanguageId = translate2.LanguageId,
                                TranslateText = translate2.FullName
                            };
                            val5.Translates.Add(val6);
                            context.Set<TModuleTranslate>().Add(val6);
                            context.Entry(val6).State = EntityState.Added;
                        }

                        continue;
                    }

                    if (
                        val5.ShortName != moduleDesc.ShortName ||
                        val5.FullName != moduleDesc.FullName ||
                        val5.SubGroup != moduleSubGroup)
                    {
                        val5.ShortName = moduleDesc.ShortName;
                        val5.FullName = moduleDesc.FullName;
                        val5.SubGroup = moduleSubGroup;

                        context.Entry(val5).State = EntityState.Modified;
                    }

                    foreach (var translateDescription in moduleDesc.Translates)
                    {
                        TModuleTranslate val7
                            = val5.Translates
                            .FirstOrDefault(moduleTranslate => moduleTranslate.LanguageId == translateDescription.LanguageId &&
                                                               moduleTranslate.ColumnName == translateDescription.ShortNameColumnName);
                        if (val7 == null)
                        {
                            val7
                                = new TModuleTranslate
                                {
                                    ColumnName = translateDescription.ShortNameColumnName,
                                    LanguageId = translateDescription.LanguageId,
                                    TranslateText = translateDescription.ShortName
                                };

                            val5.Translates.Add(val7);

                            context.Set<TModuleTranslate>().Add(val7);
                            context.Entry(val7).State = EntityState.Added;
                        }
                        else if (val7.TranslateText != translateDescription.ShortName)
                        {
                            val7.TranslateText = translateDescription.ShortName;
                            context.Entry(val7).State = EntityState.Modified;
                        }

                        TModuleTranslate val8
                            = val5.Translates.FirstOrDefault(moduleTranslate => moduleTranslate.LanguageId == translateDescription.LanguageId && moduleTranslate.ColumnName == translateDescription.FullNameColumnName);

                        if (val8 == null)
                        {
                            val8
                                = new TModuleTranslate
                                {
                                    ColumnName = translateDescription.FullNameColumnName,
                                    LanguageId = translateDescription.LanguageId,
                                    TranslateText = translateDescription.FullName
                                };

                            val5.Translates.Add(val8);

                            context.Set<TModuleTranslate>().Add(val8);
                            context.Entry(val8).State = EntityState.Added;
                        }
                        else if (val8.TranslateText != translateDescription.FullName)
                        {
                            val8.TranslateText = translateDescription.FullName;
                            context.Entry(val8).State = EntityState.Modified;
                        }
                    }

                    foreach (var item2 in val5.Translates.Where(a => !moduleDesc.Translates.Any(b => a.LanguageId == b.LanguageId && (a.ColumnName == b.ShortNameColumnName || a.ColumnName == b.FullNameColumnName))))
                        context.Entry(item2).State = EntityState.Deleted;
                }
            }

            var moduleCodes 
                = subGroupDescs.SelectMany(a => a.Value.ModuleCodes.Select((ModuleCodeDescription a) => a.Code))
                               .ToHashSet();

            foreach (TModule item3 in moduleList.Where((TModule a) => !moduleCodes.Contains(a.Code)))
            {
                context.Entry(item3).State = EntityState.Deleted;
                foreach (TModuleTranslate translate3 in item3.Translates)
                    context.Entry(translate3).State = EntityState.Deleted;

            }

            foreach (var item4 in moduleSubGroupList.Where((TModuleSubGroup a) => !subGroupDescs.ContainsKey(a.Code)))
            {
                context.Entry(item4).State = EntityState.Deleted;
                foreach (TModuleSubGroupTranslate translate4 in item4.Translates)
                    context.Entry(translate4).State = EntityState.Deleted;
            }

            context.SaveChanges();

        }
    }
}
