import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditAddBooksComponent } from './edit-add-books.component';

describe('EditAddBooksComponent', () => {
  let component: EditAddBooksComponent;
  let fixture: ComponentFixture<EditAddBooksComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EditAddBooksComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditAddBooksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
