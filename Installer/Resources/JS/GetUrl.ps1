$request = Invoke-WebRequest -Method Head -Uri $args[0]
write-host $request.BaseResponse.ResponseUri.AbsoluteUri