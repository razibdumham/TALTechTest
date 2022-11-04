import { ChangeDetectorRef, Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-calculate-premium',
  templateUrl: './calculate-premium.component.html'
})
export class CalculatePremiumComponent implements OnInit {
  public calculatePremium: PremiumCalculatorModel;
  public httpClient: HttpClient;
  public baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private cdRf: ChangeDetectorRef) {
    this.httpClient = http;
    this.baseUrl = baseUrl;
 
  }
  ngOnInit(): void {
    this.httpClient.get<PremiumCalculatorModel>(this.baseUrl + 'CalculatePremium').subscribe(result => {
      this.calculatePremium = result;
      this.cdRf.detectChanges();
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
  occupations: [];
}
