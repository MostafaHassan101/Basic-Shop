import { Component, Input } from '@angular/core';
import { ProductService as ProductService } from '../../services/product.service';
import { Product } from 'src/app/models/product';

@Component({
    selector: 'app-products-list',
    templateUrl: './products-list.component.html',
    styleUrls: ['./products-list.component.scss'],
})

export class ProductsListComponent {
    @Input() categoryProducts: any;

    dataSource!: any[];
    test: string = '';
    startEditAction = 'click';

    selectTextOnEditStart = true;
    resizingModes = ['nextColumn', 'widget'];

    columnResizingMode = this.resizingModes[0];

    products: Product[] = [];

    newProduct: Product = { name: "", price: 0, quantity: 0, isVisible: false };
    filterText: string = '';
    filteredProducts: Product[] = []; //= [...this.products];
    constructor(private productService: ProductService) {
        // this.products = productService.getStaticProducts();
        // this.filteredProducts = [...this.products];

    }

    ngOnInit() {
        this.getAllProducts();
    }

    getAllProducts() {
        this.productService.getAllProductsForAdmin().subscribe(
            {
                next: (data: Product[]) => {
                    this.products = data;
                },
                error(err) {
                },
                complete() {   
                },
            })
    }

    applyFilter() {
        // this.filteredProducts = this.products.filter(product =>
        //     product.name.toLowerCase().includes(this.filterText.toLowerCase()));

        this.productService.searchProductsForAdmin(this.filterText).subscribe({
            next: (data: Product[]) => {
                this.products = data;
                console.log(this.products);
            },
        })

    }

    onEnterKeyPress(e: any) {
        console.log(e);
        if (e.key === "Enter")
            this.applyFilter();
    }

    addProduct() {
        if (this.newProduct.name.length <= 0 || this.newProduct.price <= 0) {
            return;
        }

        this.productService.createProduct(this.newProduct).subscribe(
            {
                next: () => {
                    this.getAllProducts();
                },
                error(err) {

                },
                complete() {
                },
            }
        )
        // this.products.push({ ...this.newProduct });
        // this.filteredProducts = [...this.products];
        this.newProduct = { name: '', price: 0, quantity: 0, isVisible: false };
    }

    updateProduct(product : Product){
        this.productService.updateProduct(product).subscribe({
            next: (value) => {
                
            },
        })
    }
}
