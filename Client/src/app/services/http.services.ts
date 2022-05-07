
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from './../../environments/environment';

@Injectable({
   providedIn:'root'
})
export class HttpService {

   baseUrl = environment.baseUrl
   constructor(
      private http:HttpClient
   ){

   }

   getCategories():Observable<any>{
      return this.http.get(`${this.baseUrl}chuck/categories`)
   }

   getCategoryDetails(category:string):Observable<any>{
      return this.http.get(`${this.baseUrl}chuck/category/${category}`)
   }

   getPeople(page: number):Observable<any>{
      return this.http.get(`${this.baseUrl}swapi/people?page=${page}`)
   }

   search(searchText:string):Observable<any>{
      return this.http.get(`${this.baseUrl}search?query=${searchText}`)
   }

}