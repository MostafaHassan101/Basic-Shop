import { Injectable } from '@angular/core';
import { ApiClientService } from '../../../services/api-client.service';
import { HttpClient } from '@angular/common/http';
import { Product } from 'src/app/models/product';

@Injectable({
    providedIn: 'root'
})
export class ProductService {
    private productEndpoints = 'api/product';
    private searchEndpoints = 'api/search'
    private staticProducts : Product [] =  [
        { id:'1', name: 'Cash Money Gun', price: 43.0, quantity: 38, isVisible: true },
        { id:'2', name: 'Giant Inflatable Unicorn', price: 23.5, quantity: 3, isVisible: false },
        { id:'3', name: 'Deal With It Sunglasses', price: 11.2, quantity: 17, isVisible: true },
        { id:'4', name: 'Breaking Bad "Lego" Set', price: 699.5, quantity: 0, isVisible: true }
      ];

    constructor(private apiClientService: ApiClientService, private http: HttpClient,) { }

    getStaticProducts(){
        return this.staticProducts;
    }

    searchProductsForUser(query: string){
        return this.apiClientService.get<Product[]>(`${this.searchEndpoints}?q=${query}`)
    }

    searchProductsForAdmin(query: string){
        return this.apiClientService.get<Product[]>(`${this.searchEndpoints}/admin?q=${query}`)
    }


    getAllProductsForAdmin() {
        return this.apiClientService.get<Product[]>(`${this.productEndpoints}/admin`);
    }

    getAllProductsForUser() {
        return this.apiClientService.get<Product[]>(`${this.productEndpoints}`);
    }

    createProduct(product: Product){
        return this.apiClientService.post<any>(`${this.productEndpoints}`, product)
    }

    updateProduct(product: Product){
        return this.apiClientService.put<any>(`${this.productEndpoints}`, product)
    }
}
