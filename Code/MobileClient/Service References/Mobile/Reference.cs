﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MobileClient.Mobile {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://ysj.org/", ConfigurationName="Mobile.FKSoap")]
    public interface FKSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ysj.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ysj.org/PushAppointment", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string PushAppointment(string AppointmentId, string VisitorId, string VisitorName, string VisitorIdCard, string VisitorMobile);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ysj.org/GetDoorRecord", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        MobileClient.Mobile.TimeList[] GetDoorRecord();
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.79.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ysj.org/")]
    public partial class TimeList : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string bMCodeField;
        
        private string bMNameField;
        
        private string bMTypeField;
        
        private System.DateTime swipeTimeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string BMCode {
            get {
                return this.bMCodeField;
            }
            set {
                this.bMCodeField = value;
                this.RaisePropertyChanged("BMCode");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string BMName {
            get {
                return this.bMNameField;
            }
            set {
                this.bMNameField = value;
                this.RaisePropertyChanged("BMName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string BMType {
            get {
                return this.bMTypeField;
            }
            set {
                this.bMTypeField = value;
                this.RaisePropertyChanged("BMType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public System.DateTime SwipeTime {
            get {
                return this.swipeTimeField;
            }
            set {
                this.swipeTimeField = value;
                this.RaisePropertyChanged("SwipeTime");
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
    public interface FKSoapChannel : MobileClient.Mobile.FKSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FKSoapClient : System.ServiceModel.ClientBase<MobileClient.Mobile.FKSoap>, MobileClient.Mobile.FKSoap {
        
        public FKSoapClient() {
        }
        
        public FKSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FKSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FKSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FKSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public string PushAppointment(string AppointmentId, string VisitorId, string VisitorName, string VisitorIdCard, string VisitorMobile) {
            return base.Channel.PushAppointment(AppointmentId, VisitorId, VisitorName, VisitorIdCard, VisitorMobile);
        }
        
        public MobileClient.Mobile.TimeList[] GetDoorRecord() {
            return base.Channel.GetDoorRecord();
        }
    }
}
