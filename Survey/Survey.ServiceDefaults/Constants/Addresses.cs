using System;

namespace Survey.ServiceDefaults.Constants;

public static class Addresses
{
    public static readonly string REST_API_AI_AGENT_ANALYZE_FULL_ADDRESS =
        Environment.GetEnvironmentVariable("REST_API_AI_AGENT_ANALYZE_FULL_ADDRESS") ??
        "http://localhost:5000/analyze"; // fallback по умолчанию

    public static readonly string REST_API_AI_AGENT_ANALYZE_PARAMETER_ADDRESS =
        Environment.GetEnvironmentVariable("REST_API_AI_AGENT_ANALYZE_PARAMETER_ADDRESS") ??
        "http://localhost:5000/analyze_param?param_code=";

    public static readonly string POSTGRES_ADDRESS =
        Environment.GetEnvironmentVariable("POSTGRES_ADDRESS") ??
        "Host=5.129.192.253;Port=17300;Database=quest;Username=postgres;Password=quest-system";
}
// 