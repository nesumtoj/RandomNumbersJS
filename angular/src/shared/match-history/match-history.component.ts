import { Component, OnInit } from "@angular/core";
import { appModuleAnimation } from "@shared/animations/routerTransition";
import { MatchDto, MatchServiceProxy } from "@shared/service-proxies/service-proxies";
import { finalize } from "rxjs/operators";

@Component({
    selector: 'match-history',
    templateUrl: './match-history.component.html',
    animations: [appModuleAnimation()]
})
export class MatchHistoryComponent implements OnInit {
    matches: MatchDto[];

    constructor(
        private _matchService: MatchServiceProxy
    ) {
    }

    ngOnInit(): void {
        this.refresh();
    }

    refresh() {
        abp.ui.setBusy();
        this._matchService.getMatchHistory()
            .pipe(
                finalize(() => {
                    abp.ui.clearBusy();
                })
            ).subscribe(result => {
                this.matches = result;
            })
    }
}
