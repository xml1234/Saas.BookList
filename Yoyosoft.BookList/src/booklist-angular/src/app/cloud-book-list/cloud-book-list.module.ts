import { BooktagNzselectComponent } from './components/booktag-nzselect/booktag-nzselect.component';
import { ImgShowComponent } from './components/img-show/img-show.component';
import { CreateOrEditBookComponent } from './books/create-or-edit-book/create-or-edit-book.component';
import { TitleService } from '@yoyo/theme';
import { AbpModule, LocalizationService } from '@yoyo/abp';
import { SharedModule } from '@shared/shared.module';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CloudBookListRoutingModule } from './cloud-book-list-routing.module';
import { BookComponent } from './books/book.component';
import { BookTagComponent } from './book-tags/book-tag.component';
import { CreateOrEditBookTagComponent } from './book-tags/create-or-edit-book-tag/create-or-edit-book-tag.component';
import { CloludBookListComponent } from './clolud-book-lists/clolud-book-list.component';
import { CreateOrEditCloludBookListComponent } from './clolud-book-lists/create-or-edit-clolud-book-list/create-or-edit-clolud-book-list.component';
import { BookNzselectComponent } from './components/book-nzselect/book-nzselect.component';

@NgModule({
  imports: [
    CommonModule,

    HttpClientModule,
    SharedModule,
    AbpModule,

    CloudBookListRoutingModule
  ],
  declarations: [BookComponent, BookNzselectComponent, ImgShowComponent, BooktagNzselectComponent, CreateOrEditBookComponent, BookTagComponent,
    CreateOrEditBookTagComponent, CloludBookListComponent,
    CreateOrEditCloludBookListComponent,],
  entryComponents: [BookComponent, ImgShowComponent, CreateOrEditBookComponent, BookTagComponent,
    CreateOrEditBookTagComponent, CloludBookListComponent,
    CreateOrEditCloludBookListComponent,],
  providers: [LocalizationService, TitleService],
})
export class CloudBookListModule { }
