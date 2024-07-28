import { Component, Input } from '@angular/core';
import { ProductService } from '../modules/products/services/product.service';
import { Router } from '@angular/router';

@Component({
	selector: 'app-home-page',
	templateUrl: './home-page.component.html',
	styleUrls: ['./home-page.component.scss']
})
export class HomePageComponent {

	@Input() isVisible : boolean = true;
	@Input() headerVisible: boolean = false;
	constructor(private productService: ProductService, private route: Router) {
	}
}
