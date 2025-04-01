import { ComponentFixture, TestBed } from '@angular/core/testing';

import { YourAccountsComponent } from './your-accounts.component';

describe('YourAccountsComponent', () => {
  let component: YourAccountsComponent;
  let fixture: ComponentFixture<YourAccountsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [YourAccountsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(YourAccountsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
