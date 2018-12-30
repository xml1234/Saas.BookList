import { finalize } from 'rxjs/operators';
import { AppComponentBase } from '@shared/component-base/app-component-base';
import { Component, OnInit, Injector } from '@angular/core';
import { TenantRegistrationServiceProxy, CreateTenantDto } from '@shared/service-proxies/service-proxies';
import { LoginService } from 'account/login/login.service';
import { Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';

@Component({
  selector: 'app-tenant-register',
  templateUrl: './tenant-register.component.html',
  styles: ['./tenant-register.component.less'],
  animations: [appModuleAnimation()],
})
export class TenantRegisterComponent extends AppComponentBase implements OnInit {

  model: CreateTenantDto = new CreateTenantDto();

  constructor(injector: Injector,
    private _tenantService: TenantRegistrationServiceProxy,
    private _router: Router,
    private _loginService: LoginService) {
    super(injector);
  }

  back(): void {
    this._router.navigate(['/account/login']);
  }

  save(): void {
    this.saving = false;
    this._tenantService.registerTenant(this.model).pipe(
      finalize(() => {
        this.saving = false;
      }),
    ).subscribe(result => {
      this.notify.success(this.l('SavedSuccessfully'));
      this.saving = true;
      abp.multiTenancy.setTenantIdCookie(result.id);
      this._loginService.authenticateModel.userNameOrEmailAddress = this.model.adminEmailAddress;
      this._loginService.authenticateModel.password = this.model.password;
      this._loginService.authenticate(() => {
        this.saving = false;
      })

    });
  }

  ngOnInit() {
  }

}
