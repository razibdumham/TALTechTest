import { ChangeDetectorRef, Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-calculate-premium',
  templateUrl: './calculate-premium.component.html'
})
export class CalculatePremiumComponent implements OnInit {
  public calculatePremium: PremiumCalculatorModel = {
    name: '',
    age: 0,
    dateOfBirth: '',
    sumInsured: 0,
    ratingId: 0,
    factor: 0,
    calculatedPremium: 0,
    occupations: [],
    errors: [],
    dateOfBirthValidationError: '',
    sumInsuredValidationError:''
  };
  
  public calculatorForm = this.formBuilder.group({
    name: '',
    age: '',
    dateOfBirth: '',
    sumInsured: '',
    ratingId:''
  });
  public httpClient: HttpClient;
  public baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private cdRf: ChangeDetectorRef, private formBuilder: FormBuilder) {
    this.httpClient = http;
    this.baseUrl = baseUrl;
    
  }
  ngOnInit(): void {
    this.httpClient.get<PremiumCalculatorModel>(this.baseUrl + 'CalculatePremium').subscribe(result => {
      this.calculatePremium = result;
      this.cdRf.detectChanges();
    }, error => console.error(error));
    
  }
  onOccupationChange(event: any) {
    this.calculatePremium.name = this.calculatorForm.get('name').value||'';
    this.calculatePremium.age = parseInt(this.calculatorForm.get('age').value || 0);
    this.calculatePremium.dateOfBirth = this.calculatorForm.get('dateOfBirth').value || Date.now().toString();
    this.calculatePremium.sumInsured = parseInt(this.calculatorForm.get('sumInsured').value || 0);
    this.calculatePremium.ratingId = parseInt(event.target.value || 0);

    this.httpClient.post<any>(this.baseUrl + 'CalculatePremium', this.calculatePremium).subscribe(result => {
      this.calculatePremium = result;
      this.cdRf.detectChanges();
    }, (error: HttpErrorResponse) => {
      if (error.status === 400) {
        if (error.error.errors['DateOfBirth'] !== undefined) {
          this.calculatePremium.dateOfBirthValidationError = error.error.errors['DateOfBirth'][0];
        }
        if (error.error.errors['SumInsured'] !== undefined) {
          this.calculatePremium.sumInsuredValidationError = error.error.errors['SumInsured'][0];
        }
      }
    });
  }
  onClickSubmit() {
    this.calculatePremium.name = this.calculatorForm.get('name').value || '';
    this.calculatePremium.age = parseInt(this.calculatorForm.get('age').value || 0);
    this.calculatePremium.dateOfBirth = this.calculatorForm.get('dateOfBirth').value || Date.now().toString();
    this.calculatePremium.sumInsured = parseInt(this.calculatorForm.get('sumInsured').value || 0);
    this.calculatePremium.ratingId = parseInt(this.calculatorForm.get('ratingId').value || 0);

    this.httpClient.post<any>(this.baseUrl + 'CalculatePremium', this.calculatePremium).subscribe(result => {
      this.calculatePremium = result;
      this.cdRf.detectChanges();
    }, (error: HttpErrorResponse) => {
        if (error.status === 400) {
          if (error.error.errors['DateOfBirth'] !== undefined) {
            this.calculatePremium.dateOfBirthValidationError = error.error.errors['DateOfBirth'][0];
          }
          if (error.error.errors['SumInsured'] !== undefined) {
            this.calculatePremium.sumInsuredValidationError = error.error.errors['SumInsured'][0];
          }
          
        }
    });


  }
}

interface ClientError {
  code: string;
  description: string;
}

interface PremiumCalculatorModel {
  name: string;
  age: number;
  dateOfBirth: string;
  sumInsured: number;
  ratingId: number;
  factor: number;
  calculatedPremium: number;
  occupations: [];
  errors: [];
  dateOfBirthValidationError: string;
  sumInsuredValidationError: string;
}
