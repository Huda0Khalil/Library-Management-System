import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewAllCategoriesComponent } from './view-all-categories.component';

describe('ViewAllCategoriesComponent', () => {
  let component: ViewAllCategoriesComponent;
  let fixture: ComponentFixture<ViewAllCategoriesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ViewAllCategoriesComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewAllCategoriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
