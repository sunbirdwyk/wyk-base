using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Description;

namespace wyk.api
{
    public static class HttpConfigurationExtensions
    {
      

        /// <summary>
        /// Sets the documentation provider for help page.
        /// </summary>
        /// <param name="config">The <see cref="HttpConfiguration"/>.</param>
        /// <param name="documentationProvider">The documentation provider.</param>
        public static void SetDocumentationProvider(this HttpConfiguration config, IDocumentationProvider documentationProvider)
        {
            config.Services.Replace(typeof(IDocumentationProvider), documentationProvider);
        }

        /// <summary>
        /// Sets the objects that will be used by the formatters to produce sample requests/responses.
        /// </summary>
        /// <param name="config">The <see cref="HttpConfiguration"/>.</param>
        /// <param name="sampleObjects">The sample objects.</param>
        public static void SetSampleObjects(this HttpConfiguration config, IDictionary<Type, object> sampleObjects)
        {
            config.GetApiSpecSampleGenerator().SampleObjects = sampleObjects;
        }

        /// <summary>
        /// Sets the sample request directly for the specified media type and action.
        /// </summary>
        /// <param name="config">The <see cref="HttpConfiguration"/>.</param>
        /// <param name="sample">The sample request.</param>
        /// <param name="mediaType">The media type.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="actionName">Name of the action.</param>
        public static void SetSampleRequest(this HttpConfiguration config, object sample, MediaTypeHeaderValue mediaType, string controllerName, string actionName)
        {
            config.GetApiSpecSampleGenerator().ActionSamples.Add(new ApiSpecSampleKey(mediaType, SampleDirection.Request, controllerName, actionName, new[] { "*" }), sample);
        }

        /// <summary>
        /// Sets the sample request directly for the specified media type and action with parameters.
        /// </summary>
        /// <param name="config">The <see cref="HttpConfiguration"/>.</param>
        /// <param name="sample">The sample request.</param>
        /// <param name="mediaType">The media type.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="parameterNames">The parameter names.</param>
        public static void SetSampleRequest(this HttpConfiguration config, object sample, MediaTypeHeaderValue mediaType, string controllerName, string actionName, params string[] parameterNames)
        {
            config.GetApiSpecSampleGenerator().ActionSamples.Add(new ApiSpecSampleKey(mediaType, SampleDirection.Request, controllerName, actionName, parameterNames), sample);
        }

        /// <summary>
        /// Sets the sample request directly for the specified media type of the action.
        /// </summary>
        /// <param name="config">The <see cref="HttpConfiguration"/>.</param>
        /// <param name="sample">The sample response.</param>
        /// <param name="mediaType">The media type.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="actionName">Name of the action.</param>
        public static void SetSampleResponse(this HttpConfiguration config, object sample, MediaTypeHeaderValue mediaType, string controllerName, string actionName)
        {
            config.GetApiSpecSampleGenerator().ActionSamples.Add(new ApiSpecSampleKey(mediaType, SampleDirection.Response, controllerName, actionName, new[] { "*" }), sample);
        }

        /// <summary>
        /// Sets the sample response directly for the specified media type of the action with specific parameters.
        /// </summary>
        /// <param name="config">The <see cref="HttpConfiguration"/>.</param>
        /// <param name="sample">The sample response.</param>
        /// <param name="mediaType">The media type.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="parameterNames">The parameter names.</param>
        public static void SetSampleResponse(this HttpConfiguration config, object sample, MediaTypeHeaderValue mediaType, string controllerName, string actionName, params string[] parameterNames)
        {
            config.GetApiSpecSampleGenerator().ActionSamples.Add(new ApiSpecSampleKey(mediaType, SampleDirection.Response, controllerName, actionName, parameterNames), sample);
        }

        /// <summary>
        /// Sets the sample directly for all actions with the specified media type.
        /// </summary>
        /// <param name="config">The <see cref="HttpConfiguration"/>.</param>
        /// <param name="sample">The sample.</param>
        /// <param name="mediaType">The media type.</param>
        public static void SetSampleForMediaType(this HttpConfiguration config, object sample, MediaTypeHeaderValue mediaType)
        {
            config.GetApiSpecSampleGenerator().ActionSamples.Add(new ApiSpecSampleKey(mediaType), sample);
        }

        /// <summary>
        /// Sets the sample directly for all actions with the specified type and media type.
        /// </summary>
        /// <param name="config">The <see cref="HttpConfiguration"/>.</param>
        /// <param name="sample">The sample.</param>
        /// <param name="mediaType">The media type.</param>
        /// <param name="type">The parameter type or return type of an action.</param>
        public static void SetSampleForType(this HttpConfiguration config, object sample, MediaTypeHeaderValue mediaType, Type type)
        {
            config.GetApiSpecSampleGenerator().ActionSamples.Add(new ApiSpecSampleKey(mediaType, type), sample);
        }

        /// <summary>
        /// Specifies the actual type of <see cref="System.Net.Http.ObjectContent{T}"/> passed to the <see cref="System.Net.Http.HttpRequestMessage"/> in an action.
        /// The help page will use this information to produce more accurate request samples.
        /// </summary>
        /// <param name="config">The <see cref="HttpConfiguration"/>.</param>
        /// <param name="type">The type.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="actionName">Name of the action.</param>
        public static void SetActualRequestType(this HttpConfiguration config, Type type, string controllerName, string actionName)
        {
            config.GetApiSpecSampleGenerator().ActualHttpMessageTypes.Add(new ApiSpecSampleKey(SampleDirection.Request, controllerName, actionName, new[] { "*" }), type);
        }

        /// <summary>
        /// Specifies the actual type of <see cref="System.Net.Http.ObjectContent{T}"/> passed to the <see cref="System.Net.Http.HttpRequestMessage"/> in an action.
        /// The help page will use this information to produce more accurate request samples.
        /// </summary>
        /// <param name="config">The <see cref="HttpConfiguration"/>.</param>
        /// <param name="type">The type.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="parameterNames">The parameter names.</param>
        public static void SetActualRequestType(this HttpConfiguration config, Type type, string controllerName, string actionName, params string[] parameterNames)
        {
            config.GetApiSpecSampleGenerator().ActualHttpMessageTypes.Add(new ApiSpecSampleKey(SampleDirection.Request, controllerName, actionName, parameterNames), type);
        }

        /// <summary>
        /// Specifies the actual type of <see cref="System.Net.Http.ObjectContent{T}"/> returned as part of the <see cref="System.Net.Http.HttpRequestMessage"/> in an action.
        /// The help page will use this information to produce more accurate response samples.
        /// </summary>
        /// <param name="config">The <see cref="HttpConfiguration"/>.</param>
        /// <param name="type">The type.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="actionName">Name of the action.</param>
        public static void SetActualResponseType(this HttpConfiguration config, Type type, string controllerName, string actionName)
        {
            config.GetApiSpecSampleGenerator().ActualHttpMessageTypes.Add(new ApiSpecSampleKey(SampleDirection.Response, controllerName, actionName, new[] { "*" }), type);
        }

        /// <summary>
        /// Specifies the actual type of <see cref="System.Net.Http.ObjectContent{T}"/> returned as part of the <see cref="System.Net.Http.HttpRequestMessage"/> in an action.
        /// The help page will use this information to produce more accurate response samples.
        /// </summary>
        /// <param name="config">The <see cref="HttpConfiguration"/>.</param>
        /// <param name="type">The type.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="parameterNames">The parameter names.</param>
        public static void SetActualResponseType(this HttpConfiguration config, Type type, string controllerName, string actionName, params string[] parameterNames)
        {
            config.GetApiSpecSampleGenerator().ActualHttpMessageTypes.Add(new ApiSpecSampleKey(SampleDirection.Response, controllerName, actionName, parameterNames), type);
        }

        /// <summary>
        /// Gets the help page sample generator.
        /// </summary>
        /// <param name="config">The <see cref="HttpConfiguration"/>.</param>
        /// <returns>The help page sample generator.</returns>
        public static ApiSpecSampleGenerator GetApiSpecSampleGenerator(this HttpConfiguration config)
        {
            return (ApiSpecSampleGenerator)config.Properties.GetOrAdd(
                typeof(ApiSpecSampleGenerator),
                k => new ApiSpecSampleGenerator());
        }

        /// <summary>
        /// Sets the help page sample generator.
        /// </summary>
        /// <param name="config">The <see cref="HttpConfiguration"/>.</param>
        /// <param name="sampleGenerator">The help page sample generator.</param>
        public static void SetApiSpecSampleGenerator(this HttpConfiguration config, ApiSpecSampleGenerator sampleGenerator)
        {
            config.Properties.AddOrUpdate(
                typeof(ApiSpecSampleGenerator),
                k => sampleGenerator,
                (k, o) => sampleGenerator);
        }

        /// <summary>
        /// Gets the model description generator.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <returns>The <see cref="ModelDescriptionGenerator"/></returns>
        public static ModelDescriptionGenerator GetModelDescriptionGenerator(this HttpConfiguration config)
        {
            return (ModelDescriptionGenerator)config.Properties.GetOrAdd(
                typeof(ModelDescriptionGenerator),
                k => InitializeModelDescriptionGenerator(config));
        }

        public static List<ParameterDescription> GetUriParameters(this HttpConfiguration config, ApiDescription apiDescription)
        {
            var parameters = new List<ParameterDescription>();
            var generator = config.GetModelDescriptionGenerator();
            foreach (ApiParameterDescription apiParameter in apiDescription.ParameterDescriptions)
            {
                if (apiParameter.Source == ApiParameterSource.FromUri)
                {
                    HttpParameterDescriptor parameterDescriptor = apiParameter.ParameterDescriptor;
                    Type parameterType = null;
                    ModelDescription typeDescription = null;
                    ComplexTypeModelDescription complexTypeDescription = null;
                    if (parameterDescriptor != null)
                    {
                        parameterType = parameterDescriptor.ParameterType;
                        typeDescription = generator.GetOrCreateModelDescription(parameterType);
                        complexTypeDescription = typeDescription as ComplexTypeModelDescription;
                    }
                    if (complexTypeDescription != null
                        && !IsBindableWithTypeConverter(parameterType))
                    {
                        foreach (ParameterDescription uriParameter in complexTypeDescription.Properties)
                        {
                            parameters.Add(uriParameter);
                        }
                    }
                    else if (parameterDescriptor != null)
                    {
                        var param =
                            ParameterDescription(apiParameter, typeDescription);

                        if (!parameterDescriptor.IsOptional)
                        {
                            param.Annotations.Add(new ParameterAnnotation() { Documentation = "Required" });
                        }

                        object defaultValue = parameterDescriptor.DefaultValue;
                        if (defaultValue != null)
                        {
                            param.Annotations.Add(new ParameterAnnotation() { Documentation = "Default value is " + Convert.ToString(defaultValue, CultureInfo.InvariantCulture) });
                        }
                        parameters.Add(param);
                    }
                    else
                    {
                        Debug.Assert(parameterDescriptor == null);

                        // If parameterDescriptor is null, this is an undeclared route parameter which only occurs
                        // when source is FromUri. Ignored in request model and among resource parameters but listed
                        // as a simple string here.
                        ModelDescription modelDescription = generator.GetOrCreateModelDescription(typeof(string));
                        var param = ParameterDescription(apiParameter, modelDescription);
                        parameters.Add(param);
                    }
                }
            }
            return parameters;
        }

        private static bool IsBindableWithTypeConverter(Type parameterType)
        {
            if (parameterType == null)
            {
                return false;
            }
            return TypeDescriptor.GetConverter(parameterType).CanConvertFrom(typeof(string));
        }

        private static ParameterDescription ParameterDescription(ApiParameterDescription apiParameter, ModelDescription typeDescription)
        {
            ParameterDescription parameterDescription = new ParameterDescription
            {
                Name = apiParameter.Name,
                Documentation = apiParameter.Documentation,
                TypeDescription = typeDescription,
            };
            return parameterDescription;
        }

        public static string GetRequestDocumentation(this HttpConfiguration config, ApiDescription apiDescription)
        {
            foreach (ApiParameterDescription apiParameter in apiDescription.ParameterDescriptions)
            {
                if (apiParameter.Source == ApiParameterSource.FromBody)
                {
                    return apiParameter.Documentation;
                }
            }
            return "";
        }

        public static ModelDescription GetRequestModelDescription(this HttpConfiguration config, ApiDescription apiDescription)
        {
            foreach (ApiParameterDescription apiParameter in apiDescription.ParameterDescriptions)
            {
                if (apiParameter.Source == ApiParameterSource.FromBody)
                {
                    Type parameterType = apiParameter.ParameterDescriptor.ParameterType;
                    return config.GetModelDescriptionGenerator().GetOrCreateModelDescription(parameterType);
                }
                else if (apiParameter.ParameterDescriptor != null &&
                    apiParameter.ParameterDescriptor.ParameterType == typeof(HttpRequestMessage))
                {
                    Type parameterType = config.GetApiSpecSampleGenerator().ResolveHttpRequestMessageType(apiDescription);
                    if (parameterType != null)
                    {
                        return config.GetModelDescriptionGenerator().GetOrCreateModelDescription(parameterType);
                    }
                }
            }
            return null;
        }

        public static ModelDescription GetResourceDescription(ApiDescription apiDescription, ModelDescriptionGenerator modelGenerator)
        {
            ResponseDescription response = apiDescription.ResponseDescription;
            Type responseType = response.ResponseType ?? response.DeclaredType;
            if (responseType != null && responseType != typeof(void))
            {
                return modelGenerator.GetOrCreateModelDescription(responseType);
            }
            return null;
        }

        public static Dictionary<MediaTypeHeaderValue, object> GetRequestSamples(this HttpConfiguration config,ApiDescription apiDescription)
        {
            var samples = new Dictionary<MediaTypeHeaderValue, object>();
            try
            {
                foreach (var item in config.GetApiSpecSampleGenerator().GetSampleRequests(apiDescription))
                {
                    samples.Add(item.Key, item.Value);
                }
            }
            catch { }
            return samples;
        }

        public static string GetRequestSampleText(this HttpConfiguration config, ApiDescription apiDescription)
        {
            try
            {
                foreach (var item in config.GetApiSpecSampleGenerator().GetSampleRequests(apiDescription))
                {
                    if (item.Key.MediaType == "text/json")
                        return item.Value.ToString();
                }
            }
            catch { }
            return "";
        }

        public static Dictionary<MediaTypeHeaderValue, object> GetResponseSamples(this HttpConfiguration config, ApiDescription apiDescription)
        {
            var samples = new Dictionary<MediaTypeHeaderValue, object>();
            try
            {
                foreach (var item in config.GetApiSpecSampleGenerator().GetSampleResponses(apiDescription))
                {
                    samples.Add(item.Key, item.Value);
                }
            }
            catch { }
            return samples;
        }

        private static bool TryGetResourceParameter(ApiDescription apiDescription, HttpConfiguration config, out ApiParameterDescription parameterDescription, out Type resourceType)
        {
            parameterDescription = apiDescription.ParameterDescriptions.FirstOrDefault(
                p => p.Source == ApiParameterSource.FromBody ||
                    (p.ParameterDescriptor != null && p.ParameterDescriptor.ParameterType == typeof(HttpRequestMessage)));

            if (parameterDescription == null)
            {
                resourceType = null;
                return false;
            }

            resourceType = parameterDescription.ParameterDescriptor.ParameterType;

            if (resourceType == typeof(HttpRequestMessage))
            {
                ApiSpecSampleGenerator sampleGenerator = config.GetApiSpecSampleGenerator();
                resourceType = sampleGenerator.ResolveHttpRequestMessageType(apiDescription);
            }

            if (resourceType == null)
            {
                parameterDescription = null;
                return false;
            }

            return true;
        }

        private static ModelDescriptionGenerator InitializeModelDescriptionGenerator(HttpConfiguration config)
        {
            ModelDescriptionGenerator modelGenerator = new ModelDescriptionGenerator(config);
            Collection<ApiDescription> apis = config.Services.GetApiExplorer().ApiDescriptions;
            foreach (ApiDescription api in apis)
            {
                ApiParameterDescription parameterDescription;
                Type parameterType;
                if (TryGetResourceParameter(api, config, out parameterDescription, out parameterType))
                {
                    modelGenerator.GetOrCreateModelDescription(parameterType);
                }
            }
            return modelGenerator;
        }
    }
}
