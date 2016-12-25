namespace IAMPM.GameObjects.Exceptions
{
    public class InvalidParamExeption<T> : BaseException
    {
        public InvalidParamExeption(string propertyName, T currentValue, int? min = null, int? max = null)
            :base($"Property with name {propertyName} is invalid. Current value is {currentValue}. Min value: {min}; Max value: {max}")
        {
            
        }
    }
}