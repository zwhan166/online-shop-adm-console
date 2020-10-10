import { Component, OnInit } from '@angular/core';
import { ArticleServiceService } from "../../article-service.service";

@Component({
  selector: 'search-result',
  templateUrl: './result.component.html',
  styleUrls: ['./result.component.css']
})
export class ResultComponent implements OnInit {

  public article_data = [];

  constructor(private article_service: ArticleServiceService) { 
    console.log("--- SearchResultComponent::ctor() ---");
  }

  ngOnInit(): void {
    console.log("--- SearchResultComponent::ngOnInit() ---");
    this.article_service.getArticleData().subscribe((data) => {
      // Save the data read from the back-end.
      this.article_data = Array.from(Object.keys(data), k=>data[k]);
    });
    console.log("--- SearchResultComponent::ngOnInit() --- article_data : " + this.article_data);
  }

}
