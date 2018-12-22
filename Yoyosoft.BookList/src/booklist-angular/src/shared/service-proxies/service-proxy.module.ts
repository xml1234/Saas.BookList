import { NgModule } from '@angular/core';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AbpHttpInterceptor } from '@yoyo/abp';

import * as ApiServiceProxies from '@shared/service-proxies/service-proxies';

@NgModule({
  providers: [
    ApiServiceProxies.RoleServiceProxy,
    ApiServiceProxies.SessionServiceProxy,
    ApiServiceProxies.TenantServiceProxy,
    ApiServiceProxies.UserServiceProxy,
    ApiServiceProxies.TokenAuthServiceProxy,
    ApiServiceProxies.AccountServiceProxy,
    ApiServiceProxies.ConfigurationServiceProxy,
    ApiServiceProxies.BookServiceProxy,
    ApiServiceProxies.BookTagServiceProxy,
    ApiServiceProxies.CloludBookListServiceProxy,

    { provide: HTTP_INTERCEPTORS, useClass: AbpHttpInterceptor, multi: true },
  ],
})
export class ServiceProxyModule { }
