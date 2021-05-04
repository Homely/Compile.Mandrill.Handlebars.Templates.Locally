# Compile Mandrill Handlebars Templates Locally
As of now, the Mandrill [Render Template API](https://mailchimp.com/developer/transactional/api/templates/render-html-template/) does not support Handlebars templates. [Tweet](https://twitter.com/mandrillapp/status/622012504529481729), with more info.

So this spike will test out:
1. Downloading a Mandrill Handlebars templates
2. Compiling locally using [Handlebars.Net](https://github.com/Handlebars-Net/Handlebars.Net)
3. Substituting some data
4. Sending email via regular [Send Message API](https://mailchimp.com/developer/transactional/api/messages/send-new-message/), instead of the normal Send Message Template API.