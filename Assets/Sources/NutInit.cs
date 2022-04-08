using UnityEngine;
using Models;
using Presenter;

public class NutInit : MonoBehaviour
{
    [SerializeField] private RotationView _view;
    [SerializeField] private NutSettings _nutSettings;

    private NutInputRouter _input;
    private Transformable _transformable;
    private TransformablePresenter _presenter;
    private InertRotation _inertRotation;

    public Transformable Transformable => _transformable;

    public NutInputRouter Input => _input;

    public InertRotation InertRotation => _inertRotation;

    public TransformablePresenter Presenter => _presenter;

    private void Awake()
    {
        _transformable = new Transformable(_nutSettings);
        _inertRotation = new InertRotation(_nutSettings);
        _input = new NutInputRouter(_inertRotation, _nutSettings);
        _presenter = new TransformablePresenter(_transformable, _view);
    }

    private void OnEnable()
    {
        _input.OnEnable();
    }

    private void OnDisable()
    {
        _input.OnDisable();
    }
}