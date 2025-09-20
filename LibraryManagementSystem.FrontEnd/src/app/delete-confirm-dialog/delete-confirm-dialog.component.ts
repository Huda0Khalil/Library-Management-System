import { O } from '@angular/cdk/keycodes';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatDialogContent, MatDialogModule, MatDialogRef } from "@angular/material/dialog";
import { MatDialogActions } from '@angular/material/dialog';
@Component({
  selector: 'app-delete-confirm-dialog',
  imports: [MatDialogContent, MatDialogActions, MatDialogModule],
  templateUrl: './delete-confirm-dialog.component.html',
  styleUrl: './delete-confirm-dialog.component.css'
})
export class DeleteConfirmDialogComponent {
  @Input() type!: string;
  @Input() Id!: number;
  @Output() confirmDelete: EventEmitter<number> = new EventEmitter<number>();

  constructor(public dialogRef: MatDialogRef<DeleteConfirmDialogComponent>) { }
  onConfirm() {
    this.dialogRef.close(true); 
  }

  onCancel() {
    this.dialogRef.close(false); 
  }
}
