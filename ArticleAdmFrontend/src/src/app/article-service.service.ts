import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ArticleServiceService {

  // URL to the back-end RESTful API.
  private apiurl = "https://localhost:44352/article";

  // Data copy in the front-end.
  private article_data = [];

  constructor(private http: HttpClient) { }

  getArticleData() {
    return this.http.get(this.apiurl);
  }

  addArticleData(data) {
    console.log("--- ArticleService::addArticleData() --- " + data);
    this.http.post(this.apiurl, data);
  }

}
