import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AllegroService {
  private BASE_API_URL = environment.ALLEGRO_BASE_URL;
  constructor(private httpClient: HttpClient) {}
  getSearchProducts(phrase: string) {
    console.log(this.BASE_API_URL);
    const url = `${this.BASE_API_URL}/sale/products`;
    console.log(url);
    let qParams = new HttpParams();
    qParams = qParams.append('phrase', phrase);
    return this.httpClient.get(url, { params: qParams });
  }
}
