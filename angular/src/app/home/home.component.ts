import { Component, Injector, AfterViewInit } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { MatchDto, MatchServiceProxy } from '@shared/service-proxies/service-proxies';
import { AppAuthService } from '@shared/auth/app-auth.service';

@Component({
    templateUrl: './home.component.html',
    animations: [appModuleAnimation()]
})
export class HomeComponent extends AppComponentBase implements AfterViewInit {
    
    availableMatch: MatchDto;

    constructor(
        injector: Injector,
        private _matchService: MatchServiceProxy,
        private _authService: AppAuthService
    ) {
        super(injector);
    }

    ngAfterViewInit(): void {
        this._matchService.getNextAvailableMatch().subscribe(result => {
            this.availableMatch = result;
        });
    }

    participate() {
        if (this.availableMatch) {
            this._matchService.playMatch(this.availableMatch.id).subscribe(result => {
                abp.message.success("You have successfully participated to the match with a number of: " + result);
            });
        }
    }

    logout(): void {
        this._authService.logout();
    }
}
