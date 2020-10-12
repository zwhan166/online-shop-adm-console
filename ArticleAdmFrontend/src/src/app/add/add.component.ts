import { Component, Input, OnInit } from '@angular/core';
import { ArticleServiceService } from "../article-service.service";

@Component({
  selector: 'article-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {
  @Input() is_visible: boolean;

  data = {
    abbreviation_name: "xxx",
    full_name: "xxx xxx xxxxxx",
    specification: "a-xxx",
    creation_time: new Date(),
    update_time: new Date(),
    price: 1.99,
    discount: 0.95,
    description: "desc-xxx",
    comment: "comment-xxx",
  }

  constructor(private article_service: ArticleServiceService) { }

  ngOnInit(): void {
  }

  generate_mock_data() {
    this.data.abbreviation_name = this.generate_random_str(3) + ' ' + this.generate_random_str(3) + ' ' + this.generate_random_str(3);
    this.data.full_name = this.generate_random_str(32);
    this.data.specification = 'a-' + this.generate_random_str(6);
    this.data.update_time = new Date();
    this.data.price = this.generate_numeric_val(0, 100);
    this.data.discount = this.generate_numeric_val(0, 1);
    this.data.description = 'desc: ' + this.generate_random_str(128);
    this.data.comment = 'comment: ' + this.generate_random_str(128);
  }

  private generate_random_str(len: number) {
    var result = "";
    var buf = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    var cnt = buf.length;
    for (let idx = 0; idx < len; idx++) {
      result += buf.charAt(Math.floor(Math.random() * cnt));
    }
    return result;
  }

  private generate_numeric_val(bound1: number, bound2: number) {
    return Math.min(bound1, bound2) + (Math.random() * Math.abs(bound2 - bound1));
  }

  add_data() {
    var elem = document.getElementById('abbreviation_name');
    console.log(elem.nodeValue);

    var data_to_post = {
      "abbreviationName": this.data.abbreviation_name,
      "fullName": this.data.full_name,
      "specification": this.data.specification,
      "creationDatetime": this.data.creation_time,
      "updateDatetime": this.data.update_time,
      "price": this.data.price,
      "discount": this.data.discount
    };
    this.article_service.addArticleData(data_to_post);
  }

}
