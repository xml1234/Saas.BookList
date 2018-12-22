import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BookComponent } from './books/book.component';
import { BookTagComponent } from './book-tags/book-tag.component';
import { CloludBookListComponent } from './clolud-book-lists/clolud-book-list.component';

const routes: Routes = [
  {
    path: '',
    children: [

      { path: 'book', component: BookComponent, data: { permission: 'Pages.Book' } },
      { path: 'book-tag', component: BookTagComponent, data: { permission: 'Pages.BookTag' } },
      { path: 'clolud-book-list', component: CloludBookListComponent, data: { permission: 'Pages.CloludBookList' } },
      // {
      //   path: 'booklists',
      //   component: BookListsComponent,
      // },

    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CloudBookListRoutingModule { }
