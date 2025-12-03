abp install-libs

cd src/AbpSolution1.DbMigrator && dotnet run && cd -



cd src/AbpSolution1.Web && dotnet dev-certs https -v -ep openiddict.pfx -p config.auth_server_default_pass_phrase 


exit 0