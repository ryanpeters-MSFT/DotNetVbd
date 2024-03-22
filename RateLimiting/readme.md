# Request Rate Limiting (.NET 7)

Rate limiting in .NET is a feature that helps protect resources from being overwhelmed by too much traffic. It's a way to control the flow of requests to your application, ensuring it can handle a safe number of requests without potentially experiencing failures1. This feature was introduced as part of .NET 7.

## Types of Rate Limiters
There are several types of rate limiting algorithms provided in .NET 7:

### Fixed Window Limiter

The fixed window algorithm uses the concept of a window which is an amount of time that our limit is applied before we move on to the next window. In the fixed window case, moving to the next window means resetting the limit back to its starting point.

### Sliding Window Limiter

A sliding window rate limiter works by tracking the number of requests during a rolling time window. For example, if the limit is 100 requests per hour, the system checks the number of requests in the past hour before allowing a new request. As another example, suppose you have a limit of 500 requests per 5 minutes. This means that for any given 5-minute interval, the system allows up to 500 requests. If a new request comes in, the system checks the number of requests made in the past 5 minutes. If the number is less than 500, the request is allowed; otherwise, it's denied. This process continues for every new request, always looking at the preceding 5-minute window.

### Concurrency Limiter

This type of limiter restricts how many concurrent requests can access a resource. If your limit is 10, then 10 requests can access a resource at once and the 11th request will not be allowed.

### Token Bucket Limiter

This algorithm works by imagining a bucket filled with tokens. When a request comes in, it takes a token. After some consistent period of time, a pre-determined number of tokens are added back to the bucket. If the bucket is empty when a request comes in, the request is denied access to the resource.


**Note** - the order of `app.UseRateLimiter();` matters, as you do not want to limit requests to other parts of your application, such as authorization or for handling redirects. 

## Links
- [Rate Limiting for .NET](https://devblogs.microsoft.com/dotnet/announcing-rate-limiting-for-dotnet/)