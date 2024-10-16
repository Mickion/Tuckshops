using mickion.tuckshops.shared.application.Messages;

namespace mickion.tuckshops.shared.application.Exceptions;

public class FieldRequiredException(string message = ExceptionMessage.FIELD_IS_REQUIRED) : Exception(message) { }
   
