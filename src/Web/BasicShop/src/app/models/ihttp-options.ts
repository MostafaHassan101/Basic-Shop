import { HttpHeaders, HttpParams } from "@angular/common/http";

export interface IHttpOptions {
    headers?: HttpHeaders;
    observe?: 'body';
    params?:HttpParams | {
        [param: string]: string | string[];
    };
    reportProgress?: boolean;
    responseType?: 'json';
    withCredentials?: boolean;
}
