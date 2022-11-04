import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-calculate-premium',
  templateUrl: './calculate-premium.component.html'
})
export class CalculatePremiumComponent {
  public calculatePremium: PremiumCalculatorModel;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<PremiumCalculatorModel>(baseUrl + 'CalculatePremium').subscribe(result => {
      this.calculatePremium = result;
    }, error => console.error(error));
  }
}

interface PremiumCalculatorModel {
  name: string;
  age: number;
  date: string;
  occupationTitle: string;
  sumInsured: number;
  ratingId: number;
  ratings: [];
}
