import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  readonly ROOT_URL = "https://localhost:5001";

  constructor(private httpClient: HttpClient) { }

  get(uri: string) {
    return this.httpClient.get(`${this.ROOT_URL}/${uri}`);
  }

  post(uri: string, payload?: Object) {
    return this.httpClient.post(`${this.ROOT_URL}/${uri}`, payload);
  }

  patch(uri: string, payload: Object) {
    return this.httpClient.patch(`${this.ROOT_URL}/${uri}`, payload);
  }

  delete(uri: string) {
    return this.httpClient.delete(`${this.ROOT_URL}/${uri}`);
  }
}
