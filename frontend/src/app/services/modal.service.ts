import { Injectable } from '@angular/core';
import {NgbModal, NgbModalRef} from '@ng-bootstrap/ng-bootstrap';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ModalService {

  constructor(private modalService: NgbModal) {}

  openModal(component: any, data?: any): NgbModalRef {
    const modalRef = this.modalService.open(component);
    if(data) {
      modalRef.componentInstance.data = data;
    }
    return modalRef;
  }
  closeModal(modalRef: NgbModalRef) {
    modalRef.close();
  }
}
