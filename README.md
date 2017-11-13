Pricing Calculation Test
========================

Each tour departure has an Id, Description, and a Local Cost.  To calculate the selling price for a tour departure, the following calculations need to be applied to the local cost:

1. Convert the local cost into a cost for the selling currency.  This can be done by finding the appropriate *ExchangeRate* and calling its **Convert** method.
2. Mark up the selling currency cost using the appropriate markup rate.  This can be done by finding the appropriate *MarkupRate* and calling its **Markup** method.  

Correctly implement all unit tests in the Pricing.Tests project.

 