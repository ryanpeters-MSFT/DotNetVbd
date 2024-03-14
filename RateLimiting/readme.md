# Request Rate Limiting (.NET 7)

Allows for rate limiting of API endpoints using fixed, sliding, and concurrent configurations. 

**Note** - the order of `app.UseRateLimiter();` matters, as you do not want to limit requests to other parts of your application, such as authorization or for handling redirects. 