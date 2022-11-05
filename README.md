# Run the project
1. Clone the repository
2. Run the Solution file named "PremiumCalculation.sln" in the folder "\PremiumCalculation" using visual studio
3. Build the project. As it was done using angular js visual studio template it may take some time for first build
4. Change the connection string from the file "appsettings.json" in "\PremiumCalculation" folder. 
5. Run the command ==>> "Update-Database" to the project named "PremiumCalculation.Infrastructure" to database table and seed data

# Assumption during calculation
1. Age is calculated following western idea.
2. Age is calculated in year. So, if anyone is aged as 40 years 6 months system will consider 40 years
3. Leap year was handled during age calculation
4. Age is calculated based on Date of Birth not from the Age field of the form. Age field found from the calculator form is unused.
5. Both client side and server side validation has been done