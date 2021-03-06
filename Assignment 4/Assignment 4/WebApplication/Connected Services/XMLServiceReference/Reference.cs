﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication.XMLServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="XMLServiceReference.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/verification", ReplyAction="http://tempuri.org/IService1/verificationResponse")]
        string verification(string xmlUrl, string xslUrl);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/verification", ReplyAction="http://tempuri.org/IService1/verificationResponse")]
        System.Threading.Tasks.Task<string> verificationAsync(string xmlUrl, string xslUrl);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/transformation", ReplyAction="http://tempuri.org/IService1/transformationResponse")]
        string transformation(string xmlUrl, string xslUrl);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/transformation", ReplyAction="http://tempuri.org/IService1/transformationResponse")]
        System.Threading.Tasks.Task<string> transformationAsync(string xmlUrl, string xslUrl);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : WebApplication.XMLServiceReference.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<WebApplication.XMLServiceReference.IService1>, WebApplication.XMLServiceReference.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string verification(string xmlUrl, string xslUrl) {
            return base.Channel.verification(xmlUrl, xslUrl);
        }
        
        public System.Threading.Tasks.Task<string> verificationAsync(string xmlUrl, string xslUrl) {
            return base.Channel.verificationAsync(xmlUrl, xslUrl);
        }
        
        public string transformation(string xmlUrl, string xslUrl) {
            return base.Channel.transformation(xmlUrl, xslUrl);
        }
        
        public System.Threading.Tasks.Task<string> transformationAsync(string xmlUrl, string xslUrl) {
            return base.Channel.transformationAsync(xmlUrl, xslUrl);
        }
    }
}
