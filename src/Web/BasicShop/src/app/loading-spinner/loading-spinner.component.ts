import { Component, Input } from '@angular/core';
import { LoaderService } from '../services/loader.service';

@Component({
  selector: 'app-loading-spinner',
  templateUrl: './loading-spinner.component.html',
  styleUrls: ['./loading-spinner.component.scss']
})
export class LoadingSpinnerComponent {
  @Input() loadingVisible = false;

  constructor(public loader: LoaderService) { }

}
