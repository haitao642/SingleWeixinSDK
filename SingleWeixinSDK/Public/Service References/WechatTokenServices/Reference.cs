﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Public.WechatTokenServices {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ResultM", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class ResultM : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private bool RevField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string strRevField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string strTicketField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public bool Rev {
            get {
                return this.RevField;
            }
            set {
                if ((this.RevField.Equals(value) != true)) {
                    this.RevField = value;
                    this.RaisePropertyChanged("Rev");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string strRev {
            get {
                return this.strRevField;
            }
            set {
                if ((object.ReferenceEquals(this.strRevField, value) != true)) {
                    this.strRevField = value;
                    this.RaisePropertyChanged("strRev");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string strTicket {
            get {
                return this.strTicketField;
            }
            set {
                if ((object.ReferenceEquals(this.strTicketField, value) != true)) {
                    this.strTicketField = value;
                    this.RaisePropertyChanged("strTicket");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WechatTokenServices.WeChatSoap")]
    public interface WeChatSoap {
        
        // CODEGEN: 命名空间 http://tempuri.org/ 的元素名称 HelloWorldResult 以后生成的消息协定未标记为 nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        Public.WechatTokenServices.HelloWorldResponse HelloWorld(Public.WechatTokenServices.HelloWorldRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        System.Threading.Tasks.Task<Public.WechatTokenServices.HelloWorldResponse> HelloWorldAsync(Public.WechatTokenServices.HelloWorldRequest request);
        
        // CODEGEN: 命名空间 http://tempuri.org/ 的元素名称 appid 以后生成的消息协定未标记为 nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetWechatToken", ReplyAction="*")]
        Public.WechatTokenServices.GetWechatTokenResponse GetWechatToken(Public.WechatTokenServices.GetWechatTokenRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetWechatToken", ReplyAction="*")]
        System.Threading.Tasks.Task<Public.WechatTokenServices.GetWechatTokenResponse> GetWechatTokenAsync(Public.WechatTokenServices.GetWechatTokenRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorld", Namespace="http://tempuri.org/", Order=0)]
        public Public.WechatTokenServices.HelloWorldRequestBody Body;
        
        public HelloWorldRequest() {
        }
        
        public HelloWorldRequest(Public.WechatTokenServices.HelloWorldRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class HelloWorldRequestBody {
        
        public HelloWorldRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorldResponse", Namespace="http://tempuri.org/", Order=0)]
        public Public.WechatTokenServices.HelloWorldResponseBody Body;
        
        public HelloWorldResponse() {
        }
        
        public HelloWorldResponse(Public.WechatTokenServices.HelloWorldResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class HelloWorldResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string HelloWorldResult;
        
        public HelloWorldResponseBody() {
        }
        
        public HelloWorldResponseBody(string HelloWorldResult) {
            this.HelloWorldResult = HelloWorldResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetWechatTokenRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetWechatToken", Namespace="http://tempuri.org/", Order=0)]
        public Public.WechatTokenServices.GetWechatTokenRequestBody Body;
        
        public GetWechatTokenRequest() {
        }
        
        public GetWechatTokenRequest(Public.WechatTokenServices.GetWechatTokenRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetWechatTokenRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string appid;
        
        public GetWechatTokenRequestBody() {
        }
        
        public GetWechatTokenRequestBody(string appid) {
            this.appid = appid;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetWechatTokenResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetWechatTokenResponse", Namespace="http://tempuri.org/", Order=0)]
        public Public.WechatTokenServices.GetWechatTokenResponseBody Body;
        
        public GetWechatTokenResponse() {
        }
        
        public GetWechatTokenResponse(Public.WechatTokenServices.GetWechatTokenResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetWechatTokenResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public Public.WechatTokenServices.ResultM GetWechatTokenResult;
        
        public GetWechatTokenResponseBody() {
        }
        
        public GetWechatTokenResponseBody(Public.WechatTokenServices.ResultM GetWechatTokenResult) {
            this.GetWechatTokenResult = GetWechatTokenResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WeChatSoapChannel : Public.WechatTokenServices.WeChatSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WeChatSoapClient : System.ServiceModel.ClientBase<Public.WechatTokenServices.WeChatSoap>, Public.WechatTokenServices.WeChatSoap {
        
        public WeChatSoapClient() {
        }
        
        public WeChatSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WeChatSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WeChatSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WeChatSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Public.WechatTokenServices.HelloWorldResponse Public.WechatTokenServices.WeChatSoap.HelloWorld(Public.WechatTokenServices.HelloWorldRequest request) {
            return base.Channel.HelloWorld(request);
        }
        
        public string HelloWorld() {
            Public.WechatTokenServices.HelloWorldRequest inValue = new Public.WechatTokenServices.HelloWorldRequest();
            inValue.Body = new Public.WechatTokenServices.HelloWorldRequestBody();
            Public.WechatTokenServices.HelloWorldResponse retVal = ((Public.WechatTokenServices.WeChatSoap)(this)).HelloWorld(inValue);
            return retVal.Body.HelloWorldResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Public.WechatTokenServices.HelloWorldResponse> Public.WechatTokenServices.WeChatSoap.HelloWorldAsync(Public.WechatTokenServices.HelloWorldRequest request) {
            return base.Channel.HelloWorldAsync(request);
        }
        
        public System.Threading.Tasks.Task<Public.WechatTokenServices.HelloWorldResponse> HelloWorldAsync() {
            Public.WechatTokenServices.HelloWorldRequest inValue = new Public.WechatTokenServices.HelloWorldRequest();
            inValue.Body = new Public.WechatTokenServices.HelloWorldRequestBody();
            return ((Public.WechatTokenServices.WeChatSoap)(this)).HelloWorldAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Public.WechatTokenServices.GetWechatTokenResponse Public.WechatTokenServices.WeChatSoap.GetWechatToken(Public.WechatTokenServices.GetWechatTokenRequest request) {
            return base.Channel.GetWechatToken(request);
        }
        
        public Public.WechatTokenServices.ResultM GetWechatToken(string appid) {
            Public.WechatTokenServices.GetWechatTokenRequest inValue = new Public.WechatTokenServices.GetWechatTokenRequest();
            inValue.Body = new Public.WechatTokenServices.GetWechatTokenRequestBody();
            inValue.Body.appid = appid;
            Public.WechatTokenServices.GetWechatTokenResponse retVal = ((Public.WechatTokenServices.WeChatSoap)(this)).GetWechatToken(inValue);
            return retVal.Body.GetWechatTokenResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Public.WechatTokenServices.GetWechatTokenResponse> Public.WechatTokenServices.WeChatSoap.GetWechatTokenAsync(Public.WechatTokenServices.GetWechatTokenRequest request) {
            return base.Channel.GetWechatTokenAsync(request);
        }
        
        public System.Threading.Tasks.Task<Public.WechatTokenServices.GetWechatTokenResponse> GetWechatTokenAsync(string appid) {
            Public.WechatTokenServices.GetWechatTokenRequest inValue = new Public.WechatTokenServices.GetWechatTokenRequest();
            inValue.Body = new Public.WechatTokenServices.GetWechatTokenRequestBody();
            inValue.Body.appid = appid;
            return ((Public.WechatTokenServices.WeChatSoap)(this)).GetWechatTokenAsync(inValue);
        }
    }
}