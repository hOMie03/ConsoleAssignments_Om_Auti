import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeboardComponent } from './homeboard.component';

describe('HomeboardComponent', () => {
  let component: HomeboardComponent;
  let fixture: ComponentFixture<HomeboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HomeboardComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HomeboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
