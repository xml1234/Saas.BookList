// import { BookTagEditDto } from './../../../../shared/service-proxies/service-proxies';
import { BookTagServiceProxy, CreateOrUpdateBookTagInput, BookTagEditDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/component-base/app-component-base';
import { Component, OnInit, Injector, ViewChild, Output, Input, EventEmitter } from '@angular/core';
import { NzSelectComponent } from 'ng-zorro-antd';
import { finalize } from 'rxjs/operators';
//import { EventEmitter } from 'events';

@Component({
  selector: 'app-booktag-nzselect',
  templateUrl: './booktag-nzselect.component.html',
  styles: []
})
export class BooktagNzselectComponent extends AppComponentBase implements OnInit {

  constructor(injector: Injector, private _booktagService: BookTagServiceProxy) {
    super(injector);
  }

  // @ViewChild('booktag_select') booktag_select: NzSelectComponent;
  @ViewChild('booktagselect') booktagselect: NzSelectComponent;
  @Output()
  selectedDataChange = new EventEmitter();


  @Input()
  set tagsSourceData(value: any) {
    this.isLoading = true;
    if (value) {
      this.listOfTagOptions = value;
      this.listOfSelectedvalue = [];

      this.listOfTagOptions.forEach(item => {
        if (item.isSelected) {
          this.listOfSelectedvalue.push(item.id);
        }
      });
    }

    if (this.selectedDataChange) {
      this.selectedDataChange.emit(this.listOfSelectedvalue);
    }
    this.isLoading = false;

  };

  isLoading = true;

  listOfOption = [];
  listOfTagOptions = [];
  listOfSelectedvalue = [];

  searchValue = "";


  handleInputConfirm(e): void {
    const booktagselectvalues = this.booktagselect.listOfSelectedValue;

    for (let index = 0; index < booktagselectvalues.length; index++) {

      const element = booktagselectvalues[index];

      if (typeof element == 'number') {

      } else {
        //判断是否有创建tag得权限
        if (this.permission.isGranted('Pages.BookTag.Create')) {
          this.isLoading = true;
          // const input: CreateOrUpdateBookTagInput = new CreateOrUpdateBookTagInput();
          const BooktageditDto: BookTagEditDto = new BookTagEditDto();
          BooktageditDto.tagName = element;
          // input.bookTag = BooktageditDto;
          this._booktagService.create(BooktageditDto).pipe(finalize(() => (this.isLoading = false))).subscribe(res => {
            const listOfSelectValues = this.listOfSelectedvalue;
            const listTagOptions = this.listOfTagOptions;

            for (let selectindex = 0; selectindex < listOfSelectValues.length; selectindex++) {

              if (res.tagName === listOfSelectValues[selectindex]) {
                listTagOptions.push(res);
                listOfSelectValues[selectindex] = res.id;
              }
              //              const element = listvalues[selectindex];

            }


          });

        }

      }

    }
  }

  modelChange(): void {
    if (this.selectedDataChange) {
      this.selectedDataChange.emit(this.listOfSelectedvalue);
    }
  }

  ngOnInit() {

  }

}
