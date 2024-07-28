import { Injectable } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import notify from 'devextreme/ui/notify';

@Injectable({
	providedIn: 'root'
})
export class DialogService {

	constructor(private translateService: TranslateService) { }

	notifyError = (message: any) => {
		
		this.translateService.get(message).subscribe((res: string) => {
			
			notify({
				message: res,
				position: {
					my: 'center top',
					at: 'center top',
				}
			}, 'error', 1500);
		});
	};
	// 	notify(message, 'error', 1500);
	// };

	notifySuccess = (message: any) => {
		// notify({

		this.translateService.get(message).subscribe((res: string) => {
			notify({
				message: res,
				position: {
					my: 'center top',
					at: 'center top',
				},
			}, 'Success', 3000);
		});

		// message: message

		// 	position: {
		// 		my: 'center top',
		// 		at: 'center top',
		// 	},
		// }, 'success', 3000);
	};
}
