import { Injectable } from '@angular/core';
import { Toys } from './toys.model';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ToysService {

  constructor(private http:HttpClient) { }

  formData: Toys = new Toys();
  readonly baseURL = 'http://localhost:17729/api/Toys'

  list: Toys[];

  postToys(){
    return this.http.post(this.baseURL, this.formData);
  }

  putToys(){
    return this.http.put(`${this.baseURL}/${this.formData.id}`, this.formData);
  }

  refreshList(){
    this.http.get(this.baseURL).toPromise().then(res => this.list = res as Toys[]);
  }

  deleteToy(id:number){
    return this.http.delete(`${this.baseURL}/${id}`);
  }

}
