import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  title = 'Article Administration Console';

  is_creation_panel_visible = true;
  is_search_panel_visible = false;
  is_edit_panel_visible = false;

  show_panel(key: string) {
    this.hide_all_panels();
    if ('add' === key) {
      this.is_creation_panel_visible = true;
    } else if ('search' === key) {
      this.is_search_panel_visible = true;
    } else if ('edit' === key) {
      this.is_edit_panel_visible = true;
    }
  }

  hide_all_panels() {
    this.is_creation_panel_visible = false;
    this.is_search_panel_visible = false;
    this.is_edit_panel_visible = false;
  }
}
